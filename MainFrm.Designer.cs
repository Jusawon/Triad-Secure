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
            BackupContentViewer = new ListView();
            MainFrmMS = new MenuStrip();
            FileMn = new ToolStripMenuItem();
            OpenMn = new ToolStripMenuItem();
            IntegrityCheckMn = new ToolStripMenuItem();
            MiddleTLP = new TableLayoutPanel();
            MethodsFLP = new FlowLayoutPanel();
            HashCmb = new ComboBox();
            EncryptionCmb = new ComboBox();
            EncryptBtn = new Button();
            BackUpLbl = new Label();
            MainTLP = new TableLayoutPanel();
            SelectedFileLbl = new Label();
            SelectedFileViewer = new ListView();
            MainFrmMS.SuspendLayout();
            MiddleTLP.SuspendLayout();
            MethodsFLP.SuspendLayout();
            MainTLP.SuspendLayout();
            SuspendLayout();
            // 
            // BackupContentViewer
            // 
            BackupContentViewer.Dock = DockStyle.Fill;
            BackupContentViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            BackupContentViewer.Location = new Point(7, 460);
            BackupContentViewer.Margin = new Padding(6);
            BackupContentViewer.Name = "BackupContentViewer";
            BackupContentViewer.Size = new Size(1096, 305);
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
            // 
            // MiddleTLP
            // 
            MiddleTLP.AutoSize = true;
            MiddleTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MiddleTLP.ColumnCount = 2;
            MiddleTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.50234F));
            MiddleTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.49766F));
            MiddleTLP.Controls.Add(MethodsFLP, 1, 0);
            MiddleTLP.Controls.Add(EncryptBtn, 0, 0);
            MiddleTLP.Controls.Add(BackUpLbl, 0, 1);
            MiddleTLP.Dock = DockStyle.Fill;
            MiddleTLP.Location = new Point(4, 363);
            MiddleTLP.Margin = new Padding(3, 6, 3, 6);
            MiddleTLP.Name = "MiddleTLP";
            MiddleTLP.RowCount = 2;
            MiddleTLP.RowStyles.Add(new RowStyle());
            MiddleTLP.RowStyles.Add(new RowStyle());
            MiddleTLP.Size = new Size(1102, 84);
            MiddleTLP.TabIndex = 4;
            // 
            // MethodsFLP
            // 
            MethodsFLP.AutoSize = true;
            MethodsFLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MethodsFLP.Controls.Add(HashCmb);
            MethodsFLP.Controls.Add(EncryptionCmb);
            MethodsFLP.Dock = DockStyle.Right;
            MethodsFLP.Location = new Point(454, 4);
            MethodsFLP.Margin = new Padding(0, 4, 0, 4);
            MethodsFLP.Name = "MethodsFLP";
            MethodsFLP.Size = new Size(648, 39);
            MethodsFLP.TabIndex = 0;
            // 
            // HashCmb
            // 
            HashCmb.Dock = DockStyle.Fill;
            HashCmb.FormattingEnabled = true;
            HashCmb.Location = new Point(11, 6);
            HashCmb.Margin = new Padding(11, 6, 11, 6);
            HashCmb.MaximumSize = new Size(311, 0);
            HashCmb.Name = "HashCmb";
            HashCmb.Size = new Size(301, 33);
            HashCmb.TabIndex = 3;
            HashCmb.Text = "- Pick Your Hashing Method -";
            HashCmb.SelectedIndexChanged += HashCmb_SelectedIndexChanged;
            // 
            // EncryptionCmb
            // 
            EncryptionCmb.Dock = DockStyle.Fill;
            EncryptionCmb.FormattingEnabled = true;
            EncryptionCmb.Location = new Point(334, 6);
            EncryptionCmb.Margin = new Padding(11, 6, 11, 6);
            EncryptionCmb.MaximumSize = new Size(311, 0);
            EncryptionCmb.Name = "EncryptionCmb";
            EncryptionCmb.Size = new Size(303, 33);
            EncryptionCmb.TabIndex = 2;
            EncryptionCmb.Text = "- Pick Your Encryption Method -";
            EncryptionCmb.SelectedIndexChanged += EncryptionCmb_SelectedIndexChanged;
            // 
            // EncryptBtn
            // 
            EncryptBtn.AutoSize = true;
            EncryptBtn.Dock = DockStyle.Fill;
            EncryptBtn.Enabled = false;
            EncryptBtn.Location = new Point(33, 6);
            EncryptBtn.Margin = new Padding(33, 6, 11, 6);
            EncryptBtn.MaximumSize = new Size(222, 0);
            EncryptBtn.MinimumSize = new Size(167, 0);
            EncryptBtn.Name = "EncryptBtn";
            EncryptBtn.Size = new Size(222, 35);
            EncryptBtn.TabIndex = 0;
            EncryptBtn.Text = "&Encrypt";
            EncryptBtn.UseVisualStyleBackColor = true;
            // 
            // BackUpLbl
            // 
            BackUpLbl.AutoSize = true;
            BackUpLbl.Location = new Point(11, 53);
            BackUpLbl.Margin = new Padding(11, 6, 3, 6);
            BackUpLbl.Name = "BackUpLbl";
            BackUpLbl.Size = new Size(131, 25);
            BackUpLbl.TabIndex = 1;
            BackUpLbl.Text = "Back Up Folder";
            // 
            // MainTLP
            // 
            MainTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainTLP.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(SelectedFileLbl, 0, 0);
            MainTLP.Controls.Add(SelectedFileViewer, 0, 1);
            MainTLP.Controls.Add(BackupContentViewer, 0, 3);
            MainTLP.Controls.Add(MiddleTLP, 0, 2);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 33);
            MainTLP.Margin = new Padding(3, 4, 3, 4);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 4;
            MainTLP.RowStyles.Add(new RowStyle());
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.RowStyles.Add(new RowStyle());
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.Size = new Size(1110, 772);
            MainTLP.TabIndex = 2;
            // 
            // SelectedFileLbl
            // 
            SelectedFileLbl.AutoSize = true;
            SelectedFileLbl.Location = new Point(12, 7);
            SelectedFileLbl.Margin = new Padding(11, 6, 3, 6);
            SelectedFileLbl.Name = "SelectedFileLbl";
            SelectedFileLbl.Size = new Size(113, 25);
            SelectedFileLbl.TabIndex = 3;
            SelectedFileLbl.Text = "Selected File:";
            // 
            // SelectedFileViewer
            // 
            SelectedFileViewer.Dock = DockStyle.Fill;
            SelectedFileViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            SelectedFileViewer.Location = new Point(7, 45);
            SelectedFileViewer.Margin = new Padding(6);
            SelectedFileViewer.Name = "SelectedFileViewer";
            SelectedFileViewer.Size = new Size(1096, 305);
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
            MainMenuStrip = MainFrmMS;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1131, 861);
            Name = "MainFrm";
            Text = "Welcome To Triad Secure! ";
            Load += MainFrm_Load;
            MainFrmMS.ResumeLayout(false);
            MainFrmMS.PerformLayout();
            MiddleTLP.ResumeLayout(false);
            MiddleTLP.PerformLayout();
            MethodsFLP.ResumeLayout(false);
            MainTLP.ResumeLayout(false);
            MainTLP.PerformLayout();
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
        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.ComboBox EncryptionCmb;
        private System.Windows.Forms.ComboBox HashCmb;
        private System.Windows.Forms.FlowLayoutPanel MethodsFLP;
        private System.Windows.Forms.Label BackUpLbl;
        private System.Windows.Forms.ListView SelectedFileViewer;
        private System.Windows.Forms.Label SelectedFileLbl;
    }
}

