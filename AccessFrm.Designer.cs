namespace Triad_Secure
{
    partial class AccessFrm
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
            AccessGB = new GroupBox();
            AccountAccessViewer = new ListView();
            MainTLP = new TableLayoutPanel();
            SetBtn = new Button();
            AccessGB.SuspendLayout();
            MainTLP.SuspendLayout();
            SuspendLayout();
            // 
            // AccessGB
            // 
            AccessGB.Controls.Add(AccountAccessViewer);
            AccessGB.Dock = DockStyle.Fill;
            AccessGB.Location = new Point(3, 3);
            AccessGB.Name = "AccessGB";
            AccessGB.Size = new Size(822, 478);
            AccessGB.TabIndex = 0;
            AccessGB.TabStop = false;
            AccessGB.Text = "Configure Role Controls";
            // 
            // AccountAccessViewer
            // 
            AccountAccessViewer.Dock = DockStyle.Fill;
            AccountAccessViewer.Location = new Point(3, 27);
            AccountAccessViewer.Name = "AccountAccessViewer";
            AccountAccessViewer.Size = new Size(816, 448);
            AccountAccessViewer.TabIndex = 0;
            AccountAccessViewer.UseCompatibleStateImageBehavior = false;
            AccountAccessViewer.MouseClick += AccountAccessViewer_MouseClick;
            // 
            // MainTLP
            // 
            MainTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(AccessGB, 0, 0);
            MainTLP.Controls.Add(SetBtn, 0, 1);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 0);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 2;
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTLP.RowStyles.Add(new RowStyle());
            MainTLP.Size = new Size(828, 544);
            MainTLP.TabIndex = 1;
            // 
            // SetBtn
            // 
            SetBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SetBtn.Dock = DockStyle.Right;
            SetBtn.Location = new Point(488, 494);
            SetBtn.Margin = new Padding(40, 10, 40, 10);
            SetBtn.MaximumSize = new Size(300, 40);
            SetBtn.MinimumSize = new Size(300, 40);
            SetBtn.Name = "SetBtn";
            SetBtn.Size = new Size(300, 40);
            SetBtn.TabIndex = 1;
            SetBtn.Text = "&Set Access Controls";
            SetBtn.UseVisualStyleBackColor = true;
            SetBtn.Click += SetBtn_Click;
            // 
            // AccessFrm
            // 
            AcceptButton = SetBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(828, 544);
            ControlBox = false;
            Controls.Add(MainTLP);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccessFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Access Control";
            Load += AccessFrm_Load;
            AccessGB.ResumeLayout(false);
            MainTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox AccessGB;
        private TableLayoutPanel MainTLP;
        private Button SetBtn;
        private ListView AccountAccessViewer;
    }
}