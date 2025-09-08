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
            PassTLP = new TableLayoutPanel();
            PassLbl = new Label();
            ButtonsTLP = new TableLayoutPanel();
            OkBtn = new Button();
            CancelBtn = new Button();
            PassTxt = new TextBox();
            PassTLP.SuspendLayout();
            ButtonsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // PassTLP
            // 
            PassTLP.ColumnCount = 1;
            PassTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            PassTLP.Controls.Add(PassLbl, 0, 0);
            PassTLP.Controls.Add(ButtonsTLP, 0, 2);
            PassTLP.Controls.Add(PassTxt, 0, 1);
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
            // PassLbl
            // 
            PassLbl.AutoSize = true;
            PassLbl.Location = new Point(3, 0);
            PassLbl.Name = "PassLbl";
            PassLbl.Size = new Size(352, 25);
            PassLbl.TabIndex = 1;
            PassLbl.Text = "Enter The Passphrase For Your Secured FIle:";
            // 
            // ButtonsTLP
            // 
            ButtonsTLP.ColumnCount = 2;
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.Controls.Add(OkBtn, 0, 0);
            ButtonsTLP.Controls.Add(CancelBtn, 1, 0);
            ButtonsTLP.Dock = DockStyle.Fill;
            ButtonsTLP.Location = new Point(3, 82);
            ButtonsTLP.Name = "ButtonsTLP";
            ButtonsTLP.RowCount = 1;
            ButtonsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ButtonsTLP.Size = new Size(572, 59);
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
            OkBtn.Size = new Size(206, 39);
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
            CancelBtn.Size = new Size(206, 39);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // PassTxt
            // 
            PassTxt.Dock = DockStyle.Fill;
            PassTxt.Location = new Point(20, 45);
            PassTxt.Margin = new Padding(20, 3, 20, 3);
            PassTxt.Name = "PassTxt";
            PassTxt.PasswordChar = '*';
            PassTxt.Size = new Size(538, 31);
            PassTxt.TabIndex = 0;
            PassTxt.TextChanged += PassTxt_TextChanged;
            // 
            // PassFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 144);
            Controls.Add(PassTLP);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PassFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter Your Passphrase!";
            Load += PassFrm_Load;
            PassTLP.ResumeLayout(false);
            PassTLP.PerformLayout();
            ButtonsTLP.ResumeLayout(false);
            ButtonsTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel PassTLP;
        private TextBox PassTxt;
        private Label PassLbl;
        private TableLayoutPanel ButtonsTLP;
        private Button OkBtn;
        private Button CancelBtn;
    }
}