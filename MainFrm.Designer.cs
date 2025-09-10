namespace Triad_Secure
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            BackupContentViewer = new ListView();
            MainFrmMS = new MenuStrip();
            FileMn = new ToolStripMenuItem();
            OpenMn = new ToolStripMenuItem();
            IntegrityCheckMn = new ToolStripMenuItem();
            MiddleTLP = new TableLayoutPanel();
            ButtonsFLP = new FlowLayoutPanel();
            HashCmb = new ComboBox();
            EncryptionCmb = new ComboBox();
            ButtonsTLP = new TableLayoutPanel();
            ClearBtn = new Button();
            SecureBtn = new Button();
            MainTLP = new TableLayoutPanel();
            BackUpGB = new GroupBox();
            SelectedFileGB = new GroupBox();
            SelectedFileViewer = new ListView();
            MainFrmMS.SuspendLayout();
            MiddleTLP.SuspendLayout();
            ButtonsFLP.SuspendLayout();
            ButtonsTLP.SuspendLayout();
            MainTLP.SuspendLayout();
            BackUpGB.SuspendLayout();
            SelectedFileGB.SuspendLayout();
            SuspendLayout();
            // 
            // BackupContentViewer
            // 
            BackupContentViewer.Dock = DockStyle.Fill;
            BackupContentViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            BackupContentViewer.Location = new Point(3, 27);
            BackupContentViewer.Margin = new Padding(6);
            BackupContentViewer.Name = "BackupContentViewer";
            BackupContentViewer.Size = new Size(1096, 316);
            BackupContentViewer.TabIndex = 0;
            BackupContentViewer.UseCompatibleStateImageBehavior = false;
            // 
            // MainFrmMS
            // 
            MainFrmMS.ImageScalingSize = new Size(24, 24);
            MainFrmMS.Items.AddRange(new ToolStripItem[] { FileMn, IntegrityCheckMn });
            MainFrmMS.Location = new Point(0, 0);
            MainFrmMS.Name = "MainFrmMS";
            MainFrmMS.Padding = new Padding(7, 2, 0, 2);
            MainFrmMS.RenderMode = ToolStripRenderMode.Professional;
            MainFrmMS.Size = new Size(1110, 33);
            MainFrmMS.TabIndex = 1;
            MainFrmMS.Text = "MainFrmMS";
            // 
            // FileMn
            // 
            FileMn.DropDownItems.AddRange(new ToolStripItem[] { OpenMn });
            FileMn.Name = "FileMn";
            FileMn.Size = new Size(54, 29);
            FileMn.Text = "File";
            // 
            // OpenMn
            // 
            OpenMn.Name = "OpenMn";
            OpenMn.ShortcutKeys = Keys.Control | Keys.O;
            OpenMn.Size = new Size(223, 34);
            OpenMn.Text = "&Open";
            OpenMn.Click += OpenMn_Click;
            // 
            // IntegrityCheckMn
            // 
            IntegrityCheckMn.Name = "IntegrityCheckMn";
            IntegrityCheckMn.ShortcutKeys = Keys.Control | Keys.Shift | Keys.I;
            IntegrityCheckMn.Size = new Size(161, 29);
            IntegrityCheckMn.Text = "&Integrity Checker";
            IntegrityCheckMn.ToolTipText = "Check Integrity Between Files and Backuped Files";
            IntegrityCheckMn.Click += IntegrityCheckMn_Click;
            // 
            // MiddleTLP
            // 
            MiddleTLP.AutoSize = true;
            MiddleTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MiddleTLP.ColumnCount = 2;
            MiddleTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.50234F));
            MiddleTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.49766F));
            MiddleTLP.Controls.Add(ButtonsFLP, 1, 0);
            MiddleTLP.Controls.Add(ButtonsTLP, 0, 0);
            MiddleTLP.Dock = DockStyle.Fill;
            MiddleTLP.Location = new Point(4, 359);
            MiddleTLP.Margin = new Padding(3, 6, 3, 6);
            MiddleTLP.Name = "MiddleTLP";
            MiddleTLP.RowCount = 1;
            MiddleTLP.RowStyles.Add(new RowStyle());
            MiddleTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MiddleTLP.Size = new Size(1102, 53);
            MiddleTLP.TabIndex = 4;
            // 
            // ButtonsFLP
            // 
            ButtonsFLP.Anchor = AnchorStyles.Right;
            ButtonsFLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonsFLP.Controls.Add(HashCmb);
            ButtonsFLP.Controls.Add(EncryptionCmb);
            ButtonsFLP.Location = new Point(416, 6);
            ButtonsFLP.Margin = new Padding(3, 6, 3, 6);
            ButtonsFLP.Name = "ButtonsFLP";
            ButtonsFLP.Size = new Size(683, 41);
            ButtonsFLP.TabIndex = 1;
            // 
            // HashCmb
            // 
            HashCmb.Anchor = AnchorStyles.Right;
            HashCmb.FormattingEnabled = true;
            HashCmb.Location = new Point(3, 3);
            HashCmb.MinimumSize = new Size(300, 0);
            HashCmb.Name = "HashCmb";
            HashCmb.Size = new Size(335, 33);
            HashCmb.TabIndex = 3;
            HashCmb.Text = "- Pick Your Hashing Method -";
            HashCmb.SelectedIndexChanged += HashCmb_SelectedIndexChanged;
            // 
            // EncryptionCmb
            // 
            EncryptionCmb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            EncryptionCmb.FormattingEnabled = true;
            EncryptionCmb.Location = new Point(344, 3);
            EncryptionCmb.MinimumSize = new Size(300, 0);
            EncryptionCmb.Name = "EncryptionCmb";
            EncryptionCmb.Size = new Size(336, 33);
            EncryptionCmb.TabIndex = 2;
            EncryptionCmb.Text = "- Pick Your Encryption Method -";
            EncryptionCmb.SelectedIndexChanged += EncryptionCmb_SelectedIndexChanged;
            // 
            // ButtonsTLP
            // 
            ButtonsTLP.AutoSize = true;
            ButtonsTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonsTLP.ColumnCount = 2;
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ButtonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ButtonsTLP.Controls.Add(ClearBtn, 1, 0);
            ButtonsTLP.Controls.Add(SecureBtn, 0, 0);
            ButtonsTLP.Dock = DockStyle.Fill;
            ButtonsTLP.Location = new Point(3, 6);
            ButtonsTLP.Margin = new Padding(3, 6, 3, 6);
            ButtonsTLP.Name = "ButtonsTLP";
            ButtonsTLP.RowCount = 1;
            ButtonsTLP.RowStyles.Add(new RowStyle());
            ButtonsTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ButtonsTLP.Size = new Size(407, 41);
            ButtonsTLP.TabIndex = 5;
            // 
            // ClearBtn
            // 
            ClearBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ClearBtn.AutoSize = true;
            ClearBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClearBtn.Location = new Point(206, 3);
            ClearBtn.MinimumSize = new Size(150, 0);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(198, 35);
            ClearBtn.TabIndex = 3;
            ClearBtn.Text = "&Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // SecureBtn
            // 
            SecureBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SecureBtn.AutoSize = true;
            SecureBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SecureBtn.Enabled = false;
            SecureBtn.Location = new Point(3, 3);
            SecureBtn.MinimumSize = new Size(150, 0);
            SecureBtn.Name = "SecureBtn";
            SecureBtn.Size = new Size(197, 35);
            SecureBtn.TabIndex = 0;
            SecureBtn.Text = "&Secure";
            SecureBtn.UseVisualStyleBackColor = true;
            SecureBtn.Click += EncryptBtn_Click;
            // 
            // MainTLP
            // 
            MainTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainTLP.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(BackUpGB, 0, 2);
            MainTLP.Controls.Add(MiddleTLP, 0, 1);
            MainTLP.Controls.Add(SelectedFileGB, 0, 0);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 33);
            MainTLP.Margin = new Padding(3, 4, 3, 4);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 3;
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.RowStyles.Add(new RowStyle());
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainTLP.Size = new Size(1110, 772);
            MainTLP.TabIndex = 2;
            // 
            // BackUpGB
            // 
            BackUpGB.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackUpGB.Controls.Add(BackupContentViewer);
            BackUpGB.Dock = DockStyle.Fill;
            BackUpGB.Location = new Point(4, 422);
            BackUpGB.Name = "BackUpGB";
            BackUpGB.Size = new Size(1102, 346);
            BackUpGB.TabIndex = 4;
            BackUpGB.TabStop = false;
            BackUpGB.Text = "Back Up:";
            // 
            // SelectedFileGB
            // 
            SelectedFileGB.Controls.Add(SelectedFileViewer);
            SelectedFileGB.Dock = DockStyle.Fill;
            SelectedFileGB.Location = new Point(4, 4);
            SelectedFileGB.Name = "SelectedFileGB";
            SelectedFileGB.Size = new Size(1102, 345);
            SelectedFileGB.TabIndex = 2;
            SelectedFileGB.TabStop = false;
            SelectedFileGB.Text = "Selected File:";
            // 
            // SelectedFileViewer
            // 
            SelectedFileViewer.Dock = DockStyle.Fill;
            SelectedFileViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            SelectedFileViewer.Location = new Point(3, 27);
            SelectedFileViewer.Margin = new Padding(6);
            SelectedFileViewer.Name = "SelectedFileViewer";
            SelectedFileViewer.Size = new Size(1096, 315);
            SelectedFileViewer.TabIndex = 5;
            SelectedFileViewer.UseCompatibleStateImageBehavior = false;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 805);
            Controls.Add(MainTLP);
            Controls.Add(MainFrmMS);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainFrmMS;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1131, 861);
            Name = "MainFrm";
            Text = "Welcome To Triad Secure! ";
            Load += MainFrm_Load;
            Resize += MainFrm_Resize;
            MainFrmMS.ResumeLayout(false);
            MainFrmMS.PerformLayout();
            MiddleTLP.ResumeLayout(false);
            MiddleTLP.PerformLayout();
            ButtonsFLP.ResumeLayout(false);
            ButtonsTLP.ResumeLayout(false);
            ButtonsTLP.PerformLayout();
            MainTLP.ResumeLayout(false);
            MainTLP.PerformLayout();
            BackUpGB.ResumeLayout(false);
            SelectedFileGB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView BackupContentViewer;
        private System.Windows.Forms.MenuStrip MainFrmMS;
        private System.Windows.Forms.ToolStripMenuItem FileMn;
        private System.Windows.Forms.ToolStripMenuItem OpenMn;
        private System.Windows.Forms.ToolStripMenuItem IntegrityCheckMn;
        private System.Windows.Forms.TableLayoutPanel MainTLP;
        private System.Windows.Forms.TableLayoutPanel MiddleTLP;
        private System.Windows.Forms.Button SecureBtn;
        private System.Windows.Forms.ComboBox EncryptionCmb;
        private System.Windows.Forms.ComboBox HashCmb;
        private System.Windows.Forms.Label BackUpLbl;
        private System.Windows.Forms.ListView SelectedFileViewer;
        private System.Windows.Forms.Label SelectedFileLbl;
        private GroupBox SelectedFileGB;
        private GroupBox BackUpGB;
        private TableLayoutPanel ButtonsTLP;
        private Button ClearBtn;
        private FlowLayoutPanel ButtonsFLP;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}

