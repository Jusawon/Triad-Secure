using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triad_Secure
{
    public partial class IntegrityFrm : Form
    {
        private bool FirstFileSelected = false;
        private bool SecondFileSelected = false;
        private string FirstFilePath = string.Empty;
        private string SecondFilePath = string.Empty;

        private FileStream FirstFileStream = null;
        private FileStream SecondFileStream = null;
        private string backupFolder = Path.Combine(Application.StartupPath, "Backups");
        public IntegrityFrm()
        {
            InitializeComponent();
        }

        private void IntegrityFrm_Load(object sender, EventArgs e)
        {
            var hashAlgos = CryptoConfig.AllowOnlyFipsAlgorithms
                ? new[] { "SHA1", "SHA256", "SHA384", "SHA512" }
                : new[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" };

            HashCmb.Items.Clear();
            HashCmb.Items.Add("- Pick Your Hashing Method -");
            foreach (var algo in hashAlgos)
                HashCmb.Items.Add(algo);
            HashCmb.SelectedIndex = 0;
        }

        private void HashCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstFileSelected && SecondFileSelected && HashCmb.SelectedIndex > 0)
            {
                CompareBtn.Enabled = true;
            }
        }

        private void FirstOpenBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                // Close old stream if already open
                FirstFileStream?.Dispose();

                string selectedFile = ofd.FileName;
                string extension = Path.GetExtension(selectedFile);

                if (string.Equals(extension, ".trd", StringComparison.OrdinalIgnoreCase))
                {
                    string decryptedFile = Glb.OpenSecuredFileForIntegrity(selectedFile, this);
                    if (decryptedFile == null) return; // User canceled or wrong passphrase
                    FirstFilePath = decryptedFile;
                }
                else
                {
                    FirstFilePath = selectedFile;
                }

                FirstFileStream = new FileStream(FirstFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                FirstFileLbl.Text = "Selected File: " + Path.GetFileName(FirstFilePath);
                FirstFileSelected = true;
                ComparisonLbl.Text = "The Files Are:";
                HashCmb.Enabled = true;
                FirstTxt.Text =  "";

                if (FirstFileSelected && SecondFileSelected && HashCmb.SelectedIndex > 0)
                    CompareBtn.Enabled = true;
            }
        }

        private void SecondOpenBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                try
                {
                    string user = Environment.UserName;
                    string userBackupFolder = Path.Combine(Application.StartupPath, "Backups", user);

                    if (Directory.Exists(userBackupFolder))
                        ofd.InitialDirectory = userBackupFolder;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error accessing backup folder:\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                // Close old stream if already open
                SecondFileStream?.Dispose();

                string selectedFile = ofd.FileName;
                string extension = Path.GetExtension(selectedFile);

                if (string.Equals(extension, ".trd", StringComparison.OrdinalIgnoreCase))
                {
                    string decryptedFile = Glb.OpenSecuredFileForIntegrity(selectedFile, this);
                    if (decryptedFile == null) return; // User canceled or wrong passphrase
                    SecondFilePath = decryptedFile;
                }
                else
                {
                    SecondFilePath = selectedFile;
                }

                SecondFileStream = new FileStream(SecondFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                SecondFileLbl.Text = "Selected File: " + Path.GetFileName(SecondFilePath);
                SecondFileSelected = true;
                ComparisonLbl.Text = "The Files Are:";
                HashCmb.Enabled = true;
                SecondTxt.Text = "";

                if (FirstFileSelected && SecondFileSelected && HashCmb.SelectedIndex > 0)
                    CompareBtn.Enabled = true;
            }
        }

        private void FirstClearBtn_Click(object sender, EventArgs e)
        {
            FirstFileStream?.Dispose();
            FirstFileStream = null;

            FirstFilePath = string.Empty;
            FirstFileLbl.Text = "Selected File: ";
            FirstFileSelected = false;
            CompareBtn.Enabled = false;

            ComparisonLbl.Text = "The Files Are:";
            FirstTxt.Text = string.Empty;
            HashCmb.Enabled = true;
        }

        private void SecondClearBtn_Click(object sender, EventArgs e)
        {
            SecondFileStream?.Dispose();
            SecondFileStream = null;

            SecondFilePath = string.Empty;
            SecondFileLbl.Text = "Selected File: ";
            SecondFileSelected = false;
            CompareBtn.Enabled = false;

            ComparisonLbl.Text = "The Files Are:";
            SecondTxt.Text = string.Empty;
            HashCmb.Enabled = true;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            FirstFileStream?.Dispose();
            FirstFileStream = null;

            FirstFilePath = string.Empty;
            FirstFileLbl.Text = "Selected File: ";
            FirstFileSelected = false;

            SecondFileStream?.Dispose();
            SecondFileStream = null;

            SecondFilePath = string.Empty;
            SecondFileLbl.Text = "Selected File: ";
            SecondFileSelected = false;

            HashCmb.SelectedIndex = 0;

            CompareBtn.Enabled = false;
            ComparisonLbl.Text = "The Files Are:";
            FirstTxt.Text = string.Empty;
            SecondTxt.Text = string.Empty;
            HashCmb.Enabled = true;
        }

        private void CompareBtn_Click(object sender, EventArgs e)
        {
            string algo = HashCmb.SelectedItem.ToString();

            bool match = Glb.CheckIntegrity(algo, FirstFilePath, SecondFilePath,
                                            out string firstHash, out string secondHash);

            // Print hashes to textboxes
            FirstTxt.Text = firstHash;
            SecondTxt.Text = secondHash;

            if (match)
            {
                ComparisonLbl.Text += " A Match";
            }
            else
            {
                ComparisonLbl.Text += " Not A Match";
            }

            HashCmb.Enabled = false;
            CompareBtn.Enabled = false;
        }
    }
}