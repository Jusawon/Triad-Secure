namespace Triad_Secure
{
    partial class LoadFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PB = new ProgressBar();
            SuspendLayout();
            // 
            // PB
            // 
            PB.Dock = DockStyle.Fill;
            PB.Location = new Point(0, 0);
            PB.MarqueeAnimationSpeed = 10;
            PB.Name = "PB";
            PB.Size = new Size(778, 64);
            PB.Step = 50;
            PB.Style = ProgressBarStyle.Marquee;
            PB.TabIndex = 0;
            // 
            // LoadFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 64);
            ControlBox = false;
            Controls.Add(PB);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoadFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Processing...";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar PB;
    }
}