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
        public static class GlbOptions
        {
            public static int Pbkdf2Iterations { get; set; } = 1000; // default
            public static int SaltLength { get; set; } = 8;            // default
        }

        // Encrypt inputFile -> outputFile using PBKDF2 with chosen hash
        // Encrypt inputFile -> outputFile using PBKDF2 with chosen hash
        public static void Encrypter(string encryptionMethod, string hashMethod, string passphrase, string inputFile, string outputFile)
        {
            using (var algo = CreateSymmetricAlgorithm(encryptionMethod))
            {
                if (algo == null)
                    throw new ArgumentException($"Unsupported encryption algorithm: {encryptionMethod}");

                // Generate salt + key
                byte[] salt = GenerateSalt();
                algo.Key = DeriveKey(passphrase, salt, algo.KeySize / 8, hashMethod, GlbOptions.Pbkdf2Iterations);

                // Generate IV
                algo.GenerateIV();
                byte[] iv = algo.IV;

                using (var outFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    // --- Write plaintext header ---
                    WriteBytesWithLengthPrefix(outFs, salt);
                    WriteBytesWithLengthPrefix(outFs, iv);

                    using (var bwHeader = new BinaryWriter(outFs, Encoding.UTF8, leaveOpen: true))
                    {
                        bwHeader.Write(encryptionMethod);
                        bwHeader.Write(hashMethod);
                        bwHeader.Write(GlbOptions.Pbkdf2Iterations);

                        // Store original extension
                        string originalExt = Path.GetExtension(inputFile) ?? string.Empty;
                        bwHeader.Write(originalExt);
                    }

                    // --- Encrypt content ---
                    using (var encryptor = algo.CreateEncryptor())
                    using (var cs = new CryptoStream(outFs, encryptor, CryptoStreamMode.Write, leaveOpen: true))
                    using (var bwContent = new BinaryWriter(cs, Encoding.UTF8, leaveOpen: true))
                    using (var inFs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        // Write marker inside encrypted content
                        bwContent.Write(HeaderMarker);

                        // Copy the rest of the file
                        inFs.CopyTo(cs);
                        cs.FlushFinalBlock();
                    }
                }
            }
        }

        // --- DECRYPTION ---
        public static bool Decrypter(string passphrase, string encryptedFile, string outputFile, out string originalExtension)
        {
            originalExtension = string.Empty;

            try
            {
                using (var inFs = new FileStream(encryptedFile, FileMode.Open, FileAccess.Read))
                {
                    // Read plaintext header first
                    byte[] salt = ReadBytesWithLengthPrefix(inFs);
                    byte[] iv = ReadBytesWithLengthPrefix(inFs);

                    string encryptionMethod, hashMethod;
                    int iterations;

                    using (var brHeader = new BinaryReader(inFs, Encoding.UTF8, leaveOpen: true))
                    {
                        encryptionMethod = brHeader.ReadString();
                        hashMethod = brHeader.ReadString();
                        iterations = brHeader.ReadInt32();
                        originalExtension = brHeader.ReadString();
                    }

                    // Create algorithm + derive key
                    using (var algo = CreateSymmetricAlgorithm(encryptionMethod))
                    {
                        if (algo == null)
                            throw new ArgumentException($"Unsupported encryption algorithm: {encryptionMethod}");

                        algo.Key = DeriveKey(passphrase, salt, algo.KeySize / 8, hashMethod, iterations);
                        algo.IV = iv;

                        // Decrypt content
                        using (var decryptor = algo.CreateDecryptor())
                        using (var cs = new CryptoStream(inFs, decryptor, CryptoStreamMode.Read))
                        using (var brContent = new BinaryReader(cs, Encoding.UTF8, leaveOpen: true))
                        {
                            // Verify marker
                            string marker = brContent.ReadString();
                            if (marker != HeaderMarker) return false;

                            // Write decrypted file
                            using (var outFs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                            {
                                cs.CopyTo(outFs);
                            }

                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static void OpenSecuredFile(string securedFilePath, Form parentForm)
        {
            try
            {
                // Step 1: Check ACL
                FileInfo fi = new FileInfo(securedFilePath);
                FileSecurity fs = fi.GetAccessControl();
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();

                bool hasAccess = fs.GetAccessRules(true, true, typeof(NTAccount))
                    .OfType<FileSystemAccessRule>()
                    .Any(rule =>
                        currentUser.Name.Equals(rule.IdentityReference.Value, StringComparison.OrdinalIgnoreCase) &&
                        rule.AccessControlType == AccessControlType.Allow &&
                        (rule.FileSystemRights & FileSystemRights.ReadData) != 0);

                if (!hasAccess)
                {
                    MessageBox.Show(parentForm, "You do not have permission to access this secured file.",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Prompt for passphrase
                using (var passFrm = new PassFrm())
                {
                    if (passFrm.ShowDialog(parentForm) != DialogResult.OK) return;
                    string passphrase = passFrm.Passphrase;

                    // Step 3: Decrypt to temp file
                    string originalExtension;
                    bool success = Glb.Decrypter(passphrase, securedFilePath,
                                                  Path.Combine(Path.GetTempPath(),
                                                               Path.GetFileNameWithoutExtension(securedFilePath) + "_decrypted"),
                                                  out originalExtension);

                    if (success)
                    {
                        // Append original extension
                        string outputFile = Path.Combine(Path.GetTempPath(),
                                                         Path.GetFileNameWithoutExtension(securedFilePath) + "_decrypted" +
                                                         originalExtension);

                        // If decryption output file is different, rename it
                        string tempOutputFile = Path.Combine(Path.GetTempPath(),
                                                             Path.GetFileNameWithoutExtension(securedFilePath) + "_decrypted");
                        if (File.Exists(tempOutputFile))
                            File.Move(tempOutputFile, outputFile, overwrite: true);

                        MessageBox.Show(parentForm, $"File decrypted successfully:\n{outputFile}",
                                        "Decryption Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = outputFile,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show(parentForm, "Invalid passphrase or corrupted file.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    passphrase = string.Empty; // wipe
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(parentForm, $"Error accessing secured file:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string OpenSecuredFileForIntegrity(string securedFilePath, Form parentForm)
        {
            try
            {
                // Step 1: Check ACL
                FileInfo fi = new FileInfo(securedFilePath);
                FileSecurity fs = fi.GetAccessControl();
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();

                bool hasAccess = fs.GetAccessRules(true, true, typeof(NTAccount))
                    .OfType<FileSystemAccessRule>()
                    .Any(rule =>
                        currentUser.Name.Equals(rule.IdentityReference.Value, StringComparison.OrdinalIgnoreCase) &&
                        rule.AccessControlType == AccessControlType.Allow &&
                        (rule.FileSystemRights & FileSystemRights.ReadData) != 0);

                if (!hasAccess)
                {
                    MessageBox.Show(parentForm, "You do not have permission to access this secured file.",
                                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Step 2: Prompt for passphrase
                using var passFrm = new PassFrm();
                if (passFrm.ShowDialog(parentForm) != DialogResult.OK) return null;
                string passphrase = passFrm.Passphrase;

                // Step 3: Decrypt to temp file
                string originalExtension;
                string tempOutput = Path.Combine(Path.GetTempPath(),
                                                 Path.GetFileNameWithoutExtension(securedFilePath) + "_decrypted");

                bool success = Decrypter(passphrase, securedFilePath, tempOutput, out originalExtension);

                passphrase = string.Empty; // wipe

                if (!success)
                {
                    MessageBox.Show(parentForm, "Invalid passphrase or corrupted file.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Append original extension
                string outputFile = tempOutput + originalExtension;

                if (File.Exists(tempOutput) && tempOutput != outputFile)
                    File.Move(tempOutput, outputFile, overwrite: true);

                return outputFile; // return decrypted file path
            }
            catch (Exception ex)
            {
                MessageBox.Show(parentForm, $"Error accessing secured file:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[GlbOptions.SaltLength];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            return salt;
        }

        private static byte[] DeriveKey(string passphrase, byte[] salt, int keySizeBytes, string hashMethod, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                passphrase,
                salt,
                iterations,
                GetHashAlgorithmName(hashMethod)))
            {
                return pbkdf2.GetBytes(keySizeBytes);
            }
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
