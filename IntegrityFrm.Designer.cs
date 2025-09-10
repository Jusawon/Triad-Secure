namespace Triad_Secure
{
    partial class IntegrityFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegrityFrm));
            MainTLP = new TableLayoutPanel();
            CheckerTLP = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            HashCmb = new ComboBox();
            CompareBtn = new Button();
            ControlsClearBtn = new Button();
            ComparisonLbl = new Label();
            FirstGB = new GroupBox();
            FirstTLP = new TableLayoutPanel();
            FirstGLBControls = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            FirstOpenBtn = new Button();
            FirstClearBtn = new Button();
            FirstFileLbl = new Label();
            FirstTxt = new TextBox();
            SecondGB = new GroupBox();
            SecondTLP = new TableLayoutPanel();
            SecondGBControls = new TableLayoutPanel();
            SecondButtonsFLP = new FlowLayoutPanel();
            SecondOpenBtn = new Button();
            SecondClearBtn = new Button();
            SecondFileLbl = new Label();
            SecondTxt = new TextBox();
            MainTLP.SuspendLayout();
            CheckerTLP.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            FirstGB.SuspendLayout();
            FirstTLP.SuspendLayout();
            FirstGLBControls.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SecondGB.SuspendLayout();
            SecondTLP.SuspendLayout();
            SecondGBControls.SuspendLayout();
            SecondButtonsFLP.SuspendLayout();
            SuspendLayout();
            // 
            // MainTLP
            // 
            MainTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(CheckerTLP, 0, 1);
            MainTLP.Controls.Add(FirstGB, 0, 0);
            MainTLP.Controls.Add(SecondGB, 0, 2);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 0);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 3;
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.RowStyles.Add(new RowStyle());
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            MainTLP.Size = new Size(1178, 744);
            MainTLP.TabIndex = 0;
            // 
            // CheckerTLP
            // 
            CheckerTLP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CheckerTLP.ColumnCount = 2;
            CheckerTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.2013664F));
            CheckerTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.7986336F));
            CheckerTLP.Controls.Add(flowLayoutPanel1, 1, 0);
            CheckerTLP.Controls.Add(ComparisonLbl, 0, 0);
            CheckerTLP.Dock = DockStyle.Fill;
            CheckerTLP.Location = new Point(3, 349);
            CheckerTLP.Name = "CheckerTLP";
            CheckerTLP.RowCount = 1;
            CheckerTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CheckerTLP.Size = new Size(1172, 45);
            CheckerTLP.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(HashCmb);
            flowLayoutPanel1.Controls.Add(CompareBtn);
            flowLayoutPanel1.Controls.Add(ControlsClearBtn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(439, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(730, 39);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // HashCmb
            // 
            HashCmb.FormattingEnabled = true;
            HashCmb.Location = new Point(375, 3);
            HashCmb.Margin = new Padding(20, 3, 20, 3);
            HashCmb.MinimumSize = new Size(300, 0);
            HashCmb.Name = "HashCmb";
            HashCmb.RightToLeft = RightToLeft.No;
            HashCmb.Size = new Size(335, 33);
            HashCmb.TabIndex = 4;
            HashCmb.Text = "- Pick Your Hashing Method -";
            HashCmb.SelectedIndexChanged += HashCmb_SelectedIndexChanged;
            // 
            // CompareBtn
            // 
            CompareBtn.Dock = DockStyle.Fill;
            CompareBtn.Enabled = false;
            CompareBtn.Location = new Point(194, 3);
            CompareBtn.Margin = new Padding(3, 3, 10, 3);
            CompareBtn.Name = "CompareBtn";
            CompareBtn.Size = new Size(151, 33);
            CompareBtn.TabIndex = 5;
            CompareBtn.Text = "Compare";
            CompareBtn.UseVisualStyleBackColor = true;
            // 
            // ControlsClearBtn
            // 
            ControlsClearBtn.Dock = DockStyle.Fill;
            ControlsClearBtn.Location = new Point(30, 3);
            ControlsClearBtn.Margin = new Padding(3, 3, 10, 3);
            ControlsClearBtn.Name = "ControlsClearBtn";
            ControlsClearBtn.Size = new Size(151, 33);
            ControlsClearBtn.TabIndex = 6;
            ControlsClearBtn.Text = "Clear";
            ControlsClearBtn.UseVisualStyleBackColor = true;
            ControlsClearBtn.Click += ClearBtn_Click;
            // 
            // ComparisonLbl
            // 
            ComparisonLbl.Anchor = AnchorStyles.Left;
            ComparisonLbl.AutoSize = true;
            ComparisonLbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ComparisonLbl.Location = new Point(20, 6);
            ComparisonLbl.Margin = new Padding(20, 0, 3, 0);
            ComparisonLbl.Name = "ComparisonLbl";
            ComparisonLbl.Size = new Size(159, 32);
            ComparisonLbl.TabIndex = 6;
            ComparisonLbl.Text = "The Files Are:";
            // 
            // FirstGB
            // 
            FirstGB.Controls.Add(FirstTLP);
            FirstGB.Dock = DockStyle.Fill;
            FirstGB.Location = new Point(3, 3);
            FirstGB.Name = "FirstGB";
            FirstGB.Size = new Size(1172, 340);
            FirstGB.TabIndex = 0;
            FirstGB.TabStop = false;
            FirstGB.Text = "1st File:";
            // 
            // FirstTLP
            // 
            FirstTLP.ColumnCount = 1;
            FirstTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FirstTLP.Controls.Add(FirstGLBControls, 0, 0);
            FirstTLP.Controls.Add(FirstTxt, 0, 1);
            FirstTLP.Dock = DockStyle.Fill;
            FirstTLP.Location = new Point(3, 27);
            FirstTLP.Name = "FirstTLP";
            FirstTLP.RowCount = 2;
            FirstTLP.RowStyles.Add(new RowStyle());
            FirstTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FirstTLP.Size = new Size(1166, 310);
            FirstTLP.TabIndex = 0;
            // 
            // FirstGLBControls
            // 
            FirstGLBControls.ColumnCount = 2;
            FirstGLBControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5689678F));
            FirstGLBControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.43104F));
            FirstGLBControls.Controls.Add(flowLayoutPanel2, 0, 0);
            FirstGLBControls.Controls.Add(FirstFileLbl, 1, 0);
            FirstGLBControls.Dock = DockStyle.Fill;
            FirstGLBControls.Location = new Point(3, 3);
            FirstGLBControls.Name = "FirstGLBControls";
            FirstGLBControls.RowCount = 1;
            FirstGLBControls.RowStyles.Add(new RowStyle());
            FirstGLBControls.Size = new Size(1160, 45);
            FirstGLBControls.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(FirstOpenBtn);
            flowLayoutPanel2.Controls.Add(FirstClearBtn);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(337, 39);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // FirstOpenBtn
            // 
            FirstOpenBtn.Anchor = AnchorStyles.Left;
            FirstOpenBtn.Location = new Point(3, 3);
            FirstOpenBtn.Name = "FirstOpenBtn";
            FirstOpenBtn.Size = new Size(112, 34);
            FirstOpenBtn.TabIndex = 0;
            FirstOpenBtn.Text = "Open";
            FirstOpenBtn.UseVisualStyleBackColor = true;
            FirstOpenBtn.Click += FirstOpenBtn_Click;
            // 
            // FirstClearBtn
            // 
            FirstClearBtn.Anchor = AnchorStyles.Left;
            FirstClearBtn.Location = new Point(121, 3);
            FirstClearBtn.Name = "FirstClearBtn";
            FirstClearBtn.Size = new Size(112, 34);
            FirstClearBtn.TabIndex = 1;
            FirstClearBtn.Text = "Clear";
            FirstClearBtn.UseVisualStyleBackColor = true;
            FirstClearBtn.Click += FirstClearBtn_Click;
            // 
            // FirstFileLbl
            // 
            FirstFileLbl.Anchor = AnchorStyles.Left;
            FirstFileLbl.AutoSize = true;
            FirstFileLbl.Location = new Point(363, 10);
            FirstFileLbl.Margin = new Padding(20, 0, 3, 0);
            FirstFileLbl.Name = "FirstFileLbl";
            FirstFileLbl.Size = new Size(113, 25);
            FirstFileLbl.TabIndex = 1;
            FirstFileLbl.Text = "Selected File:";
            // 
            // FirstTxt
            // 
            FirstTxt.BackColor = SystemColors.Window;
            FirstTxt.Dock = DockStyle.Fill;
            FirstTxt.Location = new Point(3, 54);
            FirstTxt.Multiline = true;
            FirstTxt.Name = "FirstTxt";
            FirstTxt.ReadOnly = true;
            FirstTxt.ScrollBars = ScrollBars.Vertical;
            FirstTxt.Size = new Size(1160, 253);
            FirstTxt.TabIndex = 1;
            // 
            // SecondGB
            // 
            SecondGB.Controls.Add(SecondTLP);
            SecondGB.Dock = DockStyle.Fill;
            SecondGB.Location = new Point(3, 400);
            SecondGB.Name = "SecondGB";
            SecondGB.Size = new Size(1172, 341);
            SecondGB.TabIndex = 1;
            SecondGB.TabStop = false;
            SecondGB.Text = "2nd File:";
            // 
            // SecondTLP
            // 
            SecondTLP.ColumnCount = 1;
            SecondTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            SecondTLP.Controls.Add(SecondGBControls, 0, 0);
            SecondTLP.Controls.Add(SecondTxt, 0, 1);
            SecondTLP.Dock = DockStyle.Fill;
            SecondTLP.Location = new Point(3, 27);
            SecondTLP.Name = "SecondTLP";
            SecondTLP.RowCount = 2;
            SecondTLP.RowStyles.Add(new RowStyle());
            SecondTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100.000008F));
            SecondTLP.Size = new Size(1166, 311);
            SecondTLP.TabIndex = 1;
            // 
            // SecondGBControls
            // 
            SecondGBControls.ColumnCount = 2;
            SecondGBControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5689678F));
            SecondGBControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.43104F));
            SecondGBControls.Controls.Add(SecondButtonsFLP, 0, 0);
            SecondGBControls.Controls.Add(SecondFileLbl, 1, 0);
            SecondGBControls.Dock = DockStyle.Fill;
            SecondGBControls.Location = new Point(3, 3);
            SecondGBControls.Name = "SecondGBControls";
            SecondGBControls.RowCount = 1;
            SecondGBControls.RowStyles.Add(new RowStyle());
            SecondGBControls.Size = new Size(1160, 45);
            SecondGBControls.TabIndex = 0;
            // 
            // SecondButtonsFLP
            // 
            SecondButtonsFLP.Controls.Add(SecondOpenBtn);
            SecondButtonsFLP.Controls.Add(SecondClearBtn);
            SecondButtonsFLP.Dock = DockStyle.Fill;
            SecondButtonsFLP.Location = new Point(3, 3);
            SecondButtonsFLP.Name = "SecondButtonsFLP";
            SecondButtonsFLP.Size = new Size(337, 39);
            SecondButtonsFLP.TabIndex = 0;
            // 
            // SecondOpenBtn
            // 
            SecondOpenBtn.Anchor = AnchorStyles.Left;
            SecondOpenBtn.Location = new Point(3, 3);
            SecondOpenBtn.Name = "SecondOpenBtn";
            SecondOpenBtn.Size = new Size(112, 34);
            SecondOpenBtn.TabIndex = 0;
            SecondOpenBtn.Text = "Open";
            SecondOpenBtn.UseVisualStyleBackColor = true;
            SecondOpenBtn.Click += SecondOpenBtn_Click;
            // 
            // SecondClearBtn
            // 
            SecondClearBtn.Anchor = AnchorStyles.Left;
            SecondClearBtn.Location = new Point(121, 3);
            SecondClearBtn.Name = "SecondClearBtn";
            SecondClearBtn.Size = new Size(112, 34);
            SecondClearBtn.TabIndex = 1;
            SecondClearBtn.Text = "Clear";
            SecondClearBtn.UseVisualStyleBackColor = true;
            SecondClearBtn.Click += SecondClearBtn_Click;
            // 
            // SecondFileLbl
            // 
            SecondFileLbl.Anchor = AnchorStyles.Left;
            SecondFileLbl.AutoSize = true;
            SecondFileLbl.Location = new Point(363, 10);
            SecondFileLbl.Margin = new Padding(20, 0, 3, 0);
            SecondFileLbl.Name = "SecondFileLbl";
            SecondFileLbl.Size = new Size(113, 25);
            SecondFileLbl.TabIndex = 1;
            SecondFileLbl.Text = "Selected File:";
            // 
            // SecondTxt
            // 
            SecondTxt.BackColor = SystemColors.Window;
            SecondTxt.Dock = DockStyle.Fill;
            SecondTxt.Location = new Point(3, 54);
            SecondTxt.Multiline = true;
            SecondTxt.Name = "SecondTxt";
            SecondTxt.ReadOnly = true;
            SecondTxt.ScrollBars = ScrollBars.Vertical;
            SecondTxt.Size = new Size(1160, 254);
            SecondTxt.TabIndex = 1;
            // 
            // IntegrityFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(MainTLP);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1200, 800);
            Name = "IntegrityFrm";
            Text = "Check Your File's Integrity!";
            Load += IntegrityFrm_Load;
            MainTLP.ResumeLayout(false);
            CheckerTLP.ResumeLayout(false);
            CheckerTLP.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            FirstGB.ResumeLayout(false);
            FirstTLP.ResumeLayout(false);
            FirstTLP.PerformLayout();
            FirstGLBControls.ResumeLayout(false);
            FirstGLBControls.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            SecondGB.ResumeLayout(false);
            SecondTLP.ResumeLayout(false);
            SecondTLP.PerformLayout();
            SecondGBControls.ResumeLayout(false);
            SecondGBControls.PerformLayout();
            SecondButtonsFLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainTLP;
        private GroupBox SecondGB;
        private GroupBox FirstGB;
        private TableLayoutPanel FirstTLP;
        private TextBox FirstTxt;
        private TableLayoutPanel SecondTLP;
        private TableLayoutPanel SecondGBControls;
        private FlowLayoutPanel SecondButtonsFLP;
        private Button SecondOpenBtn;
        private Button SecondClearBtn;
        private Label SecondFileLbl;
        private TextBox SecondTxt;
        private ComboBox HashCmb;
        private TableLayoutPanel CheckerTLP;
        private Button CompareBtn;
        private Label ComparisonLbl;
        private Button ControlsClearBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel FirstGLBControls;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button FirstOpenBtn;
        private Button FirstClearBtn;
        private Label FirstFileLbl;
    }
}