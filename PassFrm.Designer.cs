namespace Triad_Secure
{
    partial class PassFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassFrm));
            PassTLP = new TableLayoutPanel();
            ButtonsTLP = new TableLayoutPanel();
            OkBtn = new Button();
            CancelBtn = new Button();
            InputGB = new GroupBox();
            PassTxt = new TextBox();
            PassTLP.SuspendLayout();
            ButtonsTLP.SuspendLayout();
            InputGB.SuspendLayout();
            SuspendLayout();
            // 
            // PassTLP
            // 
            PassTLP.ColumnCount = 1;
            PassTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            PassTLP.Controls.Add(ButtonsTLP, 0, 2);
            PassTLP.Controls.Add(InputGB, 0, 0);
            PassTLP.Dock = DockStyle.Fill;
            PassTLP.Location = new Point(0, 0);
            PassTLP.Name = "PassTLP";
            PassTLP.RowCount = 3;
            PassTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            PassTLP.RowStyles.Add(new RowStyle());
            PassTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            PassTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            PassTLP.Size = new Size(578, 144);
            PassTLP.TabIndex = 0;
            // 
            // ButtonsTLP
            // 
            ButtonsTLP.ColumnCount = 2;
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.Controls.Add(OkBtn, 0, 0);
            ButtonsTLP.Controls.Add(CancelBtn, 1, 0);
            ButtonsTLP.Dock = DockStyle.Fill;
            ButtonsTLP.Location = new Point(3, 60);
            ButtonsTLP.Name = "ButtonsTLP";
            ButtonsTLP.RowCount = 1;
            ButtonsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ButtonsTLP.Size = new Size(572, 81);
            ButtonsTLP.TabIndex = 5;
            // 
            // OkBtn
            // 
            OkBtn.AutoSize = true;
            OkBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OkBtn.BackColor = SystemColors.HighlightText;
            OkBtn.Dock = DockStyle.Fill;
            OkBtn.Enabled = false;
            OkBtn.ForeColor = SystemColors.Desktop;
            OkBtn.Location = new Point(40, 10);
            OkBtn.Margin = new Padding(40, 10, 40, 10);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(206, 61);
            OkBtn.TabIndex = 0;
            OkBtn.Text = "OK";
            OkBtn.UseVisualStyleBackColor = false;
            OkBtn.Click += OkBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelBtn.Dock = DockStyle.Fill;
            CancelBtn.ForeColor = SystemColors.Desktop;
            CancelBtn.Location = new Point(326, 10);
            CancelBtn.Margin = new Padding(40, 10, 40, 10);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(206, 61);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // InputGB
            // 
            InputGB.Controls.Add(PassTxt);
            InputGB.Dock = DockStyle.Fill;
            InputGB.Location = new Point(3, 3);
            InputGB.Name = "InputGB";
            InputGB.Size = new Size(572, 51);
            InputGB.TabIndex = 6;
            InputGB.TabStop = false;
            InputGB.Text = "Enter The Passphrase For Your Encrypted File:";
            // 
            // PassTxt
            // 
            PassTxt.Dock = DockStyle.Fill;
            PassTxt.Location = new Point(3, 27);
            PassTxt.Margin = new Padding(20, 3, 20, 3);
            PassTxt.Name = "PassTxt";
            PassTxt.PasswordChar = '*';
            PassTxt.Size = new Size(566, 31);
            PassTxt.TabIndex = 0;
            PassTxt.TextChanged += PassTxt_TextChanged;
            // 
            // PassFrm
            // 
            AcceptButton = OkBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 144);
            Controls.Add(PassTLP);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PassFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter Your Passphrase!";
            Load += PassFrm_Load;
            PassTLP.ResumeLayout(false);
            ButtonsTLP.ResumeLayout(false);
            ButtonsTLP.PerformLayout();
            InputGB.ResumeLayout(false);
            InputGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel PassTLP;
        private TextBox PassTxt;
        private TableLayoutPanel ButtonsTLP;
        private Button OkBtn;
        private Button CancelBtn;
        private GroupBox InputGB;
    }
}