using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triad_Secure
{
    public partial class PassFrm : Form
    {
        public string Passphrase { get; private set; } = string.Empty;
        public PassFrm()
        {
            InitializeComponent();

        }
        private void PassFrm_Load(object sender, EventArgs e)
        {
            OkBtn.Enabled = !string.IsNullOrWhiteSpace(PassTxt.Text);
        }
        private void OkBtn_Click(object sender, EventArgs e)
        {
            Passphrase = PassTxt.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PassTxt_TextChanged(object sender, EventArgs e)
        {
            OkBtn.Enabled = !string.IsNullOrWhiteSpace(PassTxt.Text);
        }
    }
}
