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
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    // Close old stream if already open
                    FirstFileStream?.Dispose();

                    FirstFilePath = ofd.FileName;
                    FirstFileLbl.Text = "Selected File: " + Path.GetFileName(FirstFilePath);
                    FirstFileSelected = true;

                    // Open stream (read-only, share read)
                    FirstFileStream = new FileStream(FirstFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                    if (FirstFileSelected && SecondFileSelected && HashCmb.SelectedIndex > 0)
                    {
                        CompareBtn.Enabled = true;
                    }
                }
            }
        }

        private void SecondOpenBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (Directory.Exists(backupFolder))
                    ofd.InitialDirectory = backupFolder;

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    // Close old stream if already open
                    SecondFileStream?.Dispose();

                    SecondFilePath = ofd.FileName;
                    SecondFileLbl.Text = "Selected File: " + Path.GetFileName(SecondFilePath);
                    SecondFileSelected = true;

                    // Open stream (read-only, share read)
                    SecondFileStream = new FileStream(SecondFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                    if (FirstFileSelected && SecondFileSelected && HashCmb.SelectedIndex > 0)
                    {
                        CompareBtn.Enabled = true;
                    }
                }
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
        }

        private void SecondClearBtn_Click(object sender, EventArgs e)
        {
            SecondFileStream?.Dispose();
            SecondFileStream = null;

            SecondFilePath = string.Empty;
            SecondFileLbl.Text = "Selected File: ";
            SecondFileSelected = false;
            CompareBtn.Enabled = false;
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
        }
    }
}
