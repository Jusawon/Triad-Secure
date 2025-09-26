namespace Triad_Secure
{
    partial class OptionsFrm
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
            components = new System.ComponentModel.Container();
            MainTLP = new TableLayoutPanel();
            ButtonsFLP = new FlowLayoutPanel();
            SetBtn = new Button();
            ResetBtn = new Button();
            ControlsTLP = new TableLayoutPanel();
            IterationLbl = new Label();
            SaltLbl = new Label();
            IterationNUD = new NumericUpDown();
            SaltNUD = new NumericUpDown();
            OptionsToolTip = new ToolTip(components);
            MainTLP.SuspendLayout();
            ButtonsFLP.SuspendLayout();
            ControlsTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IterationNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SaltNUD).BeginInit();
            SuspendLayout();
            // 
            // MainTLP
            // 
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(ButtonsFLP, 0, 1);
            MainTLP.Controls.Add(ControlsTLP, 0, 0);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 0);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 2;
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainTLP.Size = new Size(578, 244);
            MainTLP.TabIndex = 0;
            // 
            // ButtonsFLP
            // 
            ButtonsFLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonsFLP.Controls.Add(SetBtn);
            ButtonsFLP.Controls.Add(ResetBtn);
            ButtonsFLP.Dock = DockStyle.Fill;
            ButtonsFLP.FlowDirection = FlowDirection.RightToLeft;
            ButtonsFLP.Location = new Point(3, 198);
            ButtonsFLP.Name = "ButtonsFLP";
            ButtonsFLP.Size = new Size(572, 43);
            ButtonsFLP.TabIndex = 1;
            // 
            // SetBtn
            // 
            SetBtn.Anchor = AnchorStyles.Right;
            SetBtn.Location = new Point(440, 3);
            SetBtn.Margin = new Padding(3, 3, 20, 3);
            SetBtn.Name = "SetBtn";
            SetBtn.Size = new Size(112, 33);
            SetBtn.TabIndex = 0;
            SetBtn.Text = "Set";
            OptionsToolTip.SetToolTip(SetBtn, "Set Your Configurations");
            SetBtn.UseVisualStyleBackColor = true;
            SetBtn.Click += SetBtn_Click;
            // 
            // ResetBtn
            // 
            ResetBtn.Anchor = AnchorStyles.Right;
            ResetBtn.Location = new Point(305, 3);
            ResetBtn.Margin = new Padding(3, 3, 20, 3);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(112, 33);
            ResetBtn.TabIndex = 1;
            ResetBtn.Text = "Reset";
            OptionsToolTip.SetToolTip(ResetBtn, "Reset Your Configuration(s)");
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 2;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.58042F));
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.41958F));
            ControlsTLP.Controls.Add(IterationLbl, 0, 1);
            ControlsTLP.Controls.Add(SaltLbl, 0, 0);
            ControlsTLP.Controls.Add(IterationNUD, 1, 1);
            ControlsTLP.Controls.Add(SaltNUD, 1, 0);
            ControlsTLP.Dock = DockStyle.Fill;
            ControlsTLP.Location = new Point(3, 3);
            ControlsTLP.Name = "ControlsTLP";
            ControlsTLP.RowCount = 2;
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ControlsTLP.Size = new Size(572, 189);
            ControlsTLP.TabIndex = 3;
            // 
            // IterationLbl
            // 
            IterationLbl.Anchor = AnchorStyles.Left;
            IterationLbl.AutoSize = true;
            IterationLbl.Location = new Point(3, 129);
            IterationLbl.Name = "IterationLbl";
            IterationLbl.Size = new Size(90, 25);
            IterationLbl.TabIndex = 0;
            IterationLbl.Text = "Iterations:";
            // 
            // SaltLbl
            // 
            SaltLbl.Anchor = AnchorStyles.Left;
            SaltLbl.AutoSize = true;
            SaltLbl.Location = new Point(3, 34);
            SaltLbl.Name = "SaltLbl";
            SaltLbl.Size = new Size(104, 25);
            SaltLbl.TabIndex = 0;
            SaltLbl.Text = "Salt Length:";
            // 
            // IterationNUD
            // 
            IterationNUD.Anchor = AnchorStyles.Left;
            IterationNUD.BackColor = SystemColors.Window;
            IterationNUD.Location = new Point(115, 126);
            IterationNUD.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            IterationNUD.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            IterationNUD.Name = "IterationNUD";
            IterationNUD.ReadOnly = true;
            IterationNUD.Size = new Size(144, 31);
            IterationNUD.TabIndex = 1;
            OptionsToolTip.SetToolTip(IterationNUD, "Configure Your PBKDF2 Iterations");
            IterationNUD.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // SaltNUD
            // 
            SaltNUD.Anchor = AnchorStyles.Left;
            SaltNUD.BackColor = SystemColors.Window;
            SaltNUD.Location = new Point(115, 31);
            SaltNUD.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            SaltNUD.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            SaltNUD.Name = "SaltNUD";
            SaltNUD.ReadOnly = true;
            SaltNUD.Size = new Size(144, 31);
            SaltNUD.TabIndex = 1;
            OptionsToolTip.SetToolTip(SaltNUD, "Configure Your Salt Length");
            SaltNUD.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // OptionsFrm
            // 
            AcceptButton = SetBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 244);
            ControlBox = false;
            Controls.Add(MainTLP);
            Name = "OptionsFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configure Your Key!";
            Load += OptionsFrm_Load;
            MainTLP.ResumeLayout(false);
            ButtonsFLP.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ControlsTLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IterationNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)SaltNUD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainTLP;
        private Button SetBtn;
        private TableLayoutPanel ControlsTLP;
        private Label IterationLbl;
        private Label SaltLbl;
        private NumericUpDown IterationNUD;
        private NumericUpDown SaltNUD;
        private FlowLayoutPanel ButtonsFLP;
        private Button ResetBtn;
        private ToolTip OptionsToolTip;
    }
}