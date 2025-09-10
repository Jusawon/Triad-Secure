using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.IO;

namespace Triad_Secure
{
    public class Glb
    {
        private const string HeaderMarker = "TRIADSECUREv1";
        private const int Iterations = 100_000; // PBKDF2 iteration count

        // Encrypt inputFile -> outputFile using PBKDF2 with chosen hash
        public void Encrypter(string encryptionMethod, string hashMethod, string passphrase, string inputFile, string outputFile)
        {
            using (var algo = CreateSymmetricAlgorithm(encryptionMethod))
            {
                if (algo == null)
                    throw new ArgumentException($"Unsupported encryption algorithm: {encryptionMethod}");

                byte[] salt = GenerateSalt(32);

                using (var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, Iterations, GetHashAlgorithmName(hashMethod)))
                {
                    algo.Key = pbkdf2.GetBytes(algo.KeySize / 8);
                }

                algo.GenerateIV();
                byte[] iv = algo.IV;

                using (var outFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    WriteBytesWithLengthPrefix(outFs, salt);
                    WriteBytesWithLengthPrefix(outFs, iv);

                    using (var encryptor = algo.CreateEncryptor())
                    using (var cs = new CryptoStream(outFs, encryptor, CryptoStreamMode.Write, leaveOpen: true))
                    using (var bw = new BinaryWriter(cs, Encoding.UTF8, leaveOpen: true))
                    using (var inFs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        bw.Write(HeaderMarker);
                        inFs.CopyTo(cs);
                        cs.FlushFinalBlock();
                    }
                }
            }
        }

        // Verify passphrase with PBKDF2
        public bool VerifyPassphrase(string encryptionMethod, string hashMethod, string passphrase, string encryptedFile)
        {
            using (var inFs = new FileStream(encryptedFile, FileMode.Open, FileAccess.Read))
            {
                byte[] salt = ReadBytesWithLengthPrefix(inFs);
                byte[] iv = ReadBytesWithLengthPrefix(inFs);

                using (var algo = CreateSymmetricAlgorithm(encryptionMethod))
                {
                    if (algo == null)
                        throw new ArgumentException($"Unsupported encryption algorithm: {encryptionMethod}");

                    using (var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, Iterations, GetHashAlgorithmName(hashMethod)))
                    {
                        algo.Key = pbkdf2.GetBytes(algo.KeySize / 8);
                    }

                    algo.IV = iv;

                    try
                    {
                        using (var decryptor = algo.CreateDecryptor())
                        using (var cs = new CryptoStream(inFs, decryptor, CryptoStreamMode.Read, leaveOpen: true))
                        using (var br = new BinaryReader(cs, Encoding.UTF8, leaveOpen: true))
                        {
                            string marker = br.ReadString();
                            return marker == HeaderMarker;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Decrypt with PBKDF2
        public bool Decrypter(string encryptionMethod, string hashMethod, string passphrase, string encryptedFile, string outputFile)
        {
            using (var inFs = new FileStream(encryptedFile, FileMode.Open, FileAccess.Read))
            {
                byte[] salt = ReadBytesWithLengthPrefix(inFs);
                byte[] iv = ReadBytesWithLengthPrefix(inFs);

                using (var algo = CreateSymmetricAlgorithm(encryptionMethod))
                {
                    if (algo == null)
                        throw new ArgumentException($"Unsupported encryption algorithm: {encryptionMethod}");

                    using (var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, Iterations, GetHashAlgorithmName(hashMethod)))
                    {
                        algo.Key = pbkdf2.GetBytes(algo.KeySize / 8);
                    }

                    algo.IV = iv;

                    try
                    {
                        using (var decryptor = algo.CreateDecryptor())
                        using (var cs = new CryptoStream(inFs, decryptor, CryptoStreamMode.Read, leaveOpen: true))
                        using (var br = new BinaryReader(cs, Encoding.UTF8, leaveOpen: true))
                        {
                            string marker = br.ReadString();
                            if (marker != HeaderMarker) return false;

                            using (var outFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                            {
                                cs.CopyTo(outFs);
                            }
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static byte[] Hasher(string hashMethod, string filePath)
        {
            using (var hashAlg = CreateHashAlgorithm(hashMethod))
            {
                if (hashAlg == null)
                    throw new ArgumentException($"Unsupported hash algorithm: {hashMethod}");

                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    return hashAlg.ComputeHash(fs);
                }
            }
        }

        //====================ACCESS CONTROL==================
        public static void ApplyPermissions(string filePath, List<(string Account, bool Read, bool Write, bool FullControl)> selections)
        {
            var fileInfo = new FileInfo(filePath);
            FileSecurity security = fileInfo.GetAccessControl();

            // Remove all existing access rules
            foreach (FileSystemAccessRule rule in security.GetAccessRules(true, true, typeof(NTAccount)))
            {
                security.RemoveAccessRule(rule);
            }

            // Add new rules
            foreach (var sel in selections)
            {
                FileSystemRights rights = 0;
                if (sel.FullControl)
                    rights = FileSystemRights.FullControl;
                else
                {
                    if (sel.Read) rights |= FileSystemRights.Read;
                    if (sel.Write) rights |= FileSystemRights.Write;
                }

                if (rights != 0)
                {
                    var identity = new NTAccount(sel.Account);
                    var rule = new FileSystemAccessRule(identity, rights, AccessControlType.Allow);
                    security.AddAccessRule(rule);
                }
            }

            // Always ensure current user retains FullControl to prevent lockout
            string currentUser = WindowsIdentity.GetCurrent().Name;
            var fallbackRule = new FileSystemAccessRule(
                new NTAccount(currentUser),
                FileSystemRights.FullControl,
                AccessControlType.Allow
            );
            security.AddAccessRule(fallbackRule);

            // Apply the updated ACL back to the file
            fileInfo.SetAccessControl(security);
        }

        public static bool CheckIntegrity(string hashMethod, string firstFile, string secondFile, out string firstHash, out string secondHash)
        {
            var hash1 = Hasher(hashMethod, firstFile);
            var hash2 = Hasher(hashMethod, secondFile);

            firstHash = ToHex(hash1);
            secondHash = ToHex(hash2);

            return hash1.SequenceEqual(hash2);
        }

        // ===== Helpers =====
        private static void WriteBytesWithLengthPrefix(Stream s, byte[] bytes)
        {
            int len = bytes?.Length ?? 0;
            s.Write(BitConverter.GetBytes(len), 0, sizeof(int));
            if (len > 0) s.Write(bytes, 0, len);
        }

        private static byte[] ReadBytesWithLengthPrefix(Stream s)
        {
            Span<byte> intBuf = stackalloc byte[4];
            if (s.Read(intBuf) != 4) throw new InvalidDataException("Unexpected EOF");
            int len = BitConverter.ToInt32(intBuf);
            if (len < 0) throw new InvalidDataException("Negative length");
            byte[] buf = new byte[len];
            int read = 0;
            while (read < len)
            {
                int r = s.Read(buf, read, len - read);
                if (r <= 0) throw new EndOfStreamException();
                read += r;
            }
            return buf;
        }

        private static byte[] GenerateSalt(int length = 32)
        {
            byte[] salt = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            return salt;
        }

        private static SymmetricAlgorithm CreateSymmetricAlgorithm(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            switch (name.Trim().ToUpperInvariant())
            {
                case "AES":
                case "AES-128":
                case "AES-192":
                case "AES-256":
                    return Aes.Create();
                case "TRIPLEDES":
                case "3DES":
                    return TripleDES.Create();
                case "DES":
                    return DES.Create();
                case "RC2":
                    return RC2.Create();
                default:
                    throw new ArgumentException($"Unsupported symmetric algorithm: {name}");
            }
        }

        private static HashAlgorithmName GetHashAlgorithmName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Hash algorithm name cannot be empty");

            switch (name.Trim().ToUpperInvariant())
            {
                case "SHA256": return HashAlgorithmName.SHA256;
                case "SHA384": return HashAlgorithmName.SHA384;
                case "SHA512": return HashAlgorithmName.SHA512;
                case "SHA1": return HashAlgorithmName.SHA1;
                case "MD5": return HashAlgorithmName.MD5;
                default:
                    throw new ArgumentException($"Unsupported hash algorithm: {name}");
            }
        }

        private static HashAlgorithm CreateHashAlgorithm(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            switch (name.Trim().ToUpperInvariant())
            {
                case "SHA256": return SHA256.Create();
                case "SHA384": return SHA384.Create();
                case "SHA512": return SHA512.Create();
                case "SHA1": return SHA1.Create();
                case "MD5": return MD5.Create();
                default:
                    throw new ArgumentException($"Unsupported hash algorithm: {name}");
            }
        }

        public static string ToHex(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }


    }
}
