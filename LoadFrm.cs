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
    public partial class LoadFrm : Form
    {
        public LoadFrm()
        {
            InitializeComponent();
        }

        private void LoadFrm_Load(object sender, EventArgs e)
        {
            // Make progress bar continuously run
            PB.Style = ProgressBarStyle.Marquee;
        }

        // Runs a process in the background and closes the form when done
        public void RunProcess(Action action)
        {
            Task.Run(() =>
            {
                action.Invoke(); // run your encryption/decryption
                // Close form safely on UI thread
                if (InvokeRequired)
                    Invoke(new Action(() => Close()));
                else
                    Close();
            });
        }
    }
}
