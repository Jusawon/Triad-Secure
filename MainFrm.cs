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

        private string backupFolder = Path.Combine(Application.StartupPath, "Backups");
        private void MainFrm_Load(object sender, EventArgs e)
        {
            // Hash algorithms
            var hashAlgos = CryptoConfig.AllowOnlyFipsAlgorithms
                ? new[] { "SHA1", "SHA256", "SHA384", "SHA512" }
                : new[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" };

            HashCmb.Items.Clear();
            HashCmb.Items.Add("- Pick Your Hashing Method -");
            foreach (var algo in hashAlgos)
                HashCmb.Items.Add(algo);
            HashCmb.SelectedIndex = 0;

            // Symmetric encryption algorithms
            var symAlgos = new[] { "AES", "DES", "RC2", "TripleDES" };

            EncryptionCmb.Items.Clear();
            EncryptionCmb.Items.Add("- Pick Your Encryption Method -");
            foreach (var algo in symAlgos)
                EncryptionCmb.Items.Add(algo);
            EncryptionCmb.SelectedIndex = 0;


            //Ensure folder exists with Administrator-only access
            EnsureAdminOnlyFolder();

            //Setup ListView
            SetupListViews();

            //Display contents
            DisplayBackupContents();
            ResizeContent();


            /*=========================OLD CODE MIGHT NEED LATER=========================//
            // ==== Fill Hash Algorithms ====
            HashCmb.Items.Clear();
            HashCmb.Items.Add("- Pick Your Hashing Method -"); // placeholder

            var hashAlgos = typeof(HashAlgorithmName).Assembly.GetTypes()
                .Where(t => typeof(HashAlgorithmName).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name.Replace("CryptoServiceProvider", "").Replace("Managed", ""))
                .Distinct()
                .OrderBy(n => n);

            foreach (var algo in hashAlgos)
                HashCmb.Items.Add(algo);

            HashCmb.SelectedIndex = 0;


            // ==== Fill Encryption Algorithms ====
            EncryptionCmb.Items.Clear();
            EncryptionCmb.Items.Add("- Pick Your Encryption Method -"); // placeholder

            var symAlgos = typeof(SymmetricAlgorithm).Assembly.GetTypes()
                .Where(t => typeof(SymmetricAlgorithm).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name.Replace("CryptoServiceProvider", "").Replace("Managed", ""))
                .Distinct();

            foreach (var algo in symAlgos)
                EncryptionCmb.Items.Add(algo);

            EncryptionCmb.SelectedIndex = 0;

            Doubt that Asymmetric Could be implemented easily
            var asymAlgos = typeof(AsymmetricAlgorithm).Assembly.GetTypes()
                .Where(t => typeof(AsymmetricAlgorithm).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name)
                .Distinct();

            foreach (var algo in symAlgos.Concat(asymAlgos).OrderBy(n => n))
                EncryptionCmb.Items.Add(algo);
            EncryptionCmb.SelectedIndex = 0;
            */
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
            if (Directory.Exists(backupFolder))
            {
                DirectoryInfo di = new DirectoryInfo(backupFolder);
                DirectorySecurity dirSecurity = di.GetAccessControl();

                // Re-enable inheritance and clear custom rules
                dirSecurity.SetAccessRuleProtection(isProtected: false, preserveInheritance: true);

                di.SetAccessControl(dirSecurity);
            }
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

            string[] files = Directory.GetFiles(backupFolder);

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

                BackupContentViewer.Items.Add(item);
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
                    DisplaySelectedFile(ofd.FileName);
                    FileSelected = true;
                    if (HashCmb.SelectedIndex > 0 && EncryptionCmb.SelectedIndex > 0) { SecureBtn.Enabled = true; }
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


                    // Implement Salting, Encryption, And Hashing From Here On Out

                    //Clearing the passphrase
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
    }
}
