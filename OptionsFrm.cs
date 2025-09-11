using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Triad_Secure.Glb;

namespace Triad_Secure
{
    public partial class OptionsFrm : Form
    {
        public OptionsFrm()
        {
            InitializeComponent();
        }

        private void OptionsFrm_Load(object sender, EventArgs e)
        {
            SaltNUD.Value = GlbOptions.SaltLength;
            IterationNUD.Value = GlbOptions.Pbkdf2Iterations;
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            GlbOptions.Pbkdf2Iterations = (int)IterationNUD.Value;
            GlbOptions.SaltLength = (int)SaltNUD.Value;

            MessageBox.Show(
                $"PBKDF2 Iterations set to {GlbOptions.Pbkdf2Iterations}\nSalt Length set to {GlbOptions.SaltLength}",
                "Options Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            SaltNUD.Value = GlbOptions.SaltLength;
            IterationNUD.Value = GlbOptions.Pbkdf2Iterations;
        }
    }
}
