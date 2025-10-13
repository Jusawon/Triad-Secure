using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Triad_Secure.Glb;

namespace Triad_Secure
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        public string HashAlgorithm;
        public string EncryptionAlgorithm;
        private FileStream? selectedFileStream;
        private string? selectedFilePath;
        private bool FileSelected = false;
        string HelpDoc = Path.Combine(Application.StartupPath, "Help", "TriadSecureHelp.pdf");

        private string backupFolder = Path.Combine(Application.StartupPath, "Backups");
        private void MainFrm_Load(object sender, EventArgs e)
        {
            // Hash algorithms
            var hashAlgos = new[] { "SHA1", "SHA256", "SHA384", "SHA512" };

            HashCmb.Items.Clear();
            HashCmb.Items.Add("- Pick Your Hashing Method -");
            foreach (var algo in hashAlgos)
                HashCmb.Items.Add(algo);
            HashCmb.SelectedIndex = 0;

            // Symmetric encryption algorithms
            var symAlgos = new[] { "AES-128", "AES-192", "AES-256", "TripleDES-128", "TripleDES-192", "DES", "RC2" };

            EncryptionCmb.Items.Clear();
            EncryptionCmb.Items.Add("- Pick Your Encryption Method -");
            foreach (var algo in symAlgos)
                EncryptionCmb.Items.Add(algo);
            EncryptionCmb.SelectedIndex = 0;


            //Ensure folder exists with Administrator-only access
            EnsureAdminOnlyFolder();
            EnsureUserBackupFolder();

            //Setup ListView
            SetupListViews();

            //Display contents
            DisplayBackupContents();
            ResizeContent();



        }

        private void EnsureAdminOnlyFolder()
        {
            if (!Directory.Exists(backupFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(backupFolder);

                // Set up Security
                DirectorySecurity dirSecurity = di.GetAccessControl();
                dirSecurity.SetAccessRuleProtection(isProtected: true, preserveInheritance: false);

                // Remove existing rules
                var rules = dirSecurity.GetAccessRules(true, true, typeof(NTAccount));
                foreach (FileSystemAccessRule rule in rules)
                {
                    dirSecurity.RemoveAccessRule(rule);
                }

                // Grant Full Control to Administrators only
                FileSystemAccessRule adminRule = new FileSystemAccessRule(
                    new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null),
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                dirSecurity.AddAccessRule(adminRule);
                di.SetAccessControl(dirSecurity);
            }

            //DELETE THIS LATER, just for testing :)
            //if (Directory.Exists(backupFolder))
            //{
            //    DirectoryInfo di = new DirectoryInfo(backupFolder);
            //    DirectorySecurity dirSecurity = di.GetAccessControl();

            //    // Re-enable inheritance and clear custom rules
            //    dirSecurity.SetAccessRuleProtection(isProtected: false, preserveInheritance: true);

            //    di.SetAccessControl(dirSecurity);
            //}
        }

        private void EnsureUserBackupFolder()
        {
            // Use current Windows user
            string userName = Environment.UserName;
            string userFolder = Path.Combine(backupFolder, userName);

            if (!Directory.Exists(userFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(userFolder);

                // Security: Only this user has Full Control
                DirectorySecurity dirSecurity = new DirectorySecurity();
                dirSecurity.SetAccessRuleProtection(isProtected: true, preserveInheritance: false);

                // Remove any inherited rules
                var rules = dirSecurity.GetAccessRules(true, true, typeof(NTAccount));
                foreach (FileSystemAccessRule rule in rules)
                {
                    dirSecurity.RemoveAccessRule(rule);
                }

                // Current user SID
                var currentUserSid = WindowsIdentity.GetCurrent().User;

                FileSystemAccessRule userRule = new FileSystemAccessRule(
                    currentUserSid,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                dirSecurity.AddAccessRule(userRule);

                di.SetAccessControl(dirSecurity);
            }

            // DEBUG/TEST ONLY: reset inheritance afterwards
            //if (Directory.Exists(userFolder))
            //{
            //    DirectoryInfo di = new DirectoryInfo(userFolder);
            //    DirectorySecurity dirSecurity = di.GetAccessControl();

            //    // Re-enable inheritance (for testing only)
            //    dirSecurity.SetAccessRuleProtection(isProtected: false, preserveInheritance: true);
            //    di.SetAccessControl(dirSecurity);
            //}
        }


        private void MainFrm_Resize(object sender, EventArgs e)
        {
            ResizeContent();
        }

        private void SetupListViews()
        {
            // ==== BackupContentViewer ====
            BackupContentViewer.View = View.Details;
            BackupContentViewer.Columns.Clear();
            BackupContentViewer.Columns.Add("Name", 200);
            BackupContentViewer.Columns.Add("Size", 100);
            BackupContentViewer.Columns.Add("Created", 150);
            BackupContentViewer.Columns.Add("Modified", 150);

            BackupContentViewer.SmallImageList = new ImageList();
            BackupContentViewer.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            BackupContentViewer.SmallImageList.ImageSize = new Size(16, 16);

            // ==== SelectedFileViewer ====
            SelectedFileViewer.View = View.Details;
            SelectedFileViewer.Columns.Clear();
            SelectedFileViewer.Columns.Add("Name", 200);
            SelectedFileViewer.Columns.Add("Size", 100);
            SelectedFileViewer.Columns.Add("Created", 150);
            SelectedFileViewer.Columns.Add("Modified", 150);

            SelectedFileViewer.SmallImageList = new ImageList();
            SelectedFileViewer.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            SelectedFileViewer.SmallImageList.ImageSize = new Size(16, 16);
        }

        private void DisplayBackupContents()
        {
            BackupContentViewer.Items.Clear();
            BackupContentViewer.SmallImageList.Images.Clear();

            string userName = Environment.UserName;
            string userFolder = Path.Combine(backupFolder, userName);

            // Default to global folder if user folder doesn't exist
            string targetFolder = Directory.Exists(userFolder) ? userFolder : backupFolder;

            try
            {
                string[] files = Directory.GetFiles(targetFolder);

                foreach (string file in files)
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(file);
                    BackupContentViewer.SmallImageList.Images.Add(file, fileIcon);

                    FileInfo fi = new FileInfo(file);

                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add((fi.Length / 1024) + " KB");
                    item.SubItems.Add(fi.CreationTime.ToString());
                    item.SubItems.Add(fi.LastWriteTime.ToString());
                    item.ImageKey = file;

                    // Store full path for later retrieval
                    item.Tag = file;

                    BackupContentViewer.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load backup contents:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySelectedFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);

            SelectedFileViewer.Items.Clear();

            ListViewItem item = new ListViewItem(fi.Name);
            item.SubItems.Add((fi.Length / 1024) + " KB");
            item.SubItems.Add(fi.CreationTime.ToString());
            item.SubItems.Add(fi.LastWriteTime.ToString());

            SelectedFileViewer.Items.Add(item);

            // Dispose old stream if it exists
            selectedFileStream?.Dispose();

            // Open new stream for the selected file
            selectedFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            selectedFilePath = filePath;
        }

        //Resizing the MainFrm Contents

        private void HashCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HashCmb.SelectedIndex == 0 || EncryptionCmb.SelectedIndex == 0 || !FileSelected)
            {
                SecureBtn.Enabled = false;
            }
            else
            {
                SecureBtn.Enabled = true;
            }
        }


        private void EncryptionCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HashCmb.SelectedIndex == 0 || EncryptionCmb.SelectedIndex == 0 || !FileSelected)
            {
                SecureBtn.Enabled = false;
            }
            else
            {
                SecureBtn.Enabled = true;
            }
        }

        private void OpenMn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "All Files (*.*)|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName)?.ToLowerInvariant();

                    // Block .trd or already secured files
                    if (ext == ".trd")
                    {
                        MessageBox.Show("Unable to select secured (.trd) files.",
                                        "Invalid Selection",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    DisplaySelectedFile(ofd.FileName);
                    FileSelected = true;

                    if (HashCmb.SelectedIndex > 0 && EncryptionCmb.SelectedIndex > 0)
                    {
                        SecureBtn.Enabled = true;
                    }
                }
            }
        }
        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            if (HashCmb.SelectedIndex > 0 && EncryptionCmb.SelectedIndex > 0 && FileSelected)
            {
                HashAlgorithm = HashCmb.SelectedItem.ToString();
                EncryptionAlgorithm = EncryptionCmb.SelectedItem.ToString();
            }

            using (var passFrm = new PassFrm())
            {
                if (passFrm.ShowDialog(this) == DialogResult.OK)
                {
                    string passphrase = passFrm.Passphrase;

                    using (var optionsFrm = new OptionsFrm())
                    {
                        if (optionsFrm.ShowDialog(this) == DialogResult.OK)
                        {
                            string inputFile = selectedFilePath!;
                            string userName = Environment.UserName;
                            string userFolder = Path.Combine(backupFolder, userName);


                            string backupOutputFile = Path.Combine(
                                userFolder,
                                Path.GetFileNameWithoutExtension(inputFile) + ".trd"
                            );

                            string localOutputFile = Path.Combine(
                                Path.GetDirectoryName(inputFile)!,
                                Path.GetFileNameWithoutExtension(inputFile) + ".trd"
                            );

                            Encrypter(EncryptionAlgorithm, HashAlgorithm, passphrase, inputFile, backupOutputFile);

                            File.Copy(backupOutputFile, localOutputFile, overwrite: true);

                            using (var accessFrm = new AccessFrm())
                            {
                                if (accessFrm.ShowDialog(this) == DialogResult.OK)
                                {
                                    var selections = accessFrm.GetSelections(); // implement this in AccessFrm
                                    Glb.ApplyPermissions(backupOutputFile, selections);
                                    Glb.ApplyPermissions(localOutputFile, selections);

                                    MessageBox.Show(
                                        "File was successfully encrypted and secured.\n" +
                                        $"Backup: {backupOutputFile}\nLocal copy: {localOutputFile}",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    DisplayBackupContents();
                    // Reset global values and clear sensitive data
                    GlbOptions.SaltLength = 8;
                    GlbOptions.Pbkdf2Iterations = 1000;
                    passphrase = string.Empty;
                }
            }
        }

        private void ResizeContent()
        {
            if (BackupContentViewer.Columns.Count > 0)
            {
                int totalWidth = BackupContentViewer.ClientSize.Width;

                BackupContentViewer.Columns[0].Width = (int)(totalWidth * 0.4);  // Name = 40%
                BackupContentViewer.Columns[1].Width = (int)(totalWidth * 0.2);  // Size = 20%
                BackupContentViewer.Columns[2].Width = (int)(totalWidth * 0.2);  // Created = 20%
                BackupContentViewer.Columns[3].Width = (int)(totalWidth * 0.2);  // Modified = 20%
            }

            if (SelectedFileViewer.Columns.Count > 0)
            {
                int totalWidth = SelectedFileViewer.ClientSize.Width;

                SelectedFileViewer.Columns[0].Width = (int)(totalWidth * 0.4);  // Name = 40%
                SelectedFileViewer.Columns[1].Width = (int)(totalWidth * 0.2);  // Size = 20%
                SelectedFileViewer.Columns[2].Width = (int)(totalWidth * 0.2);  // Created = 20%
                SelectedFileViewer.Columns[3].Width = (int)(totalWidth * 0.2);  // Modified = 20%
            }
        }
        private void IntegrityCheckMn_Click(object sender, EventArgs e)
        {
            var frm = new IntegrityFrm();
            frm.Show(this);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            HashCmb.SelectedIndex = 0;
            EncryptionCmb.SelectedIndex = 0;
            SelectedFileViewer.Items.Clear();
            selectedFileStream?.Dispose();
            FileSelected = false;
        }


        private void BackupContentViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (BackupContentViewer.SelectedItems.Count == 0) return;

            var item = BackupContentViewer.SelectedItems[0];
            string filePath = item.Tag as string;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Invalid file selection.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenSecuredFile(filePath, this);
        }

        private void DecryptMn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a secured .trd file to decrypt";
                ofd.Filter = "Secured Files (*.trd)|*.trd";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    string selectedFile = ofd.FileName;

                    // Call the existing OpenSecuredFile function
                    Glb.OpenSecuredFile(selectedFile, this);
                }
            }
        }

        private void HelpMn_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(HelpDoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file with associated application: " + ex.Message);
            }
        }
    }
}
