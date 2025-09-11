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
            MainTLP = new TableLayoutPanel();
            SetBtn = new Button();
            ControlsTLP = new TableLayoutPanel();
            IterationLbl = new Label();
            KeyLbl = new Label();
            IterationNUD = new NumericUpDown();
            KeyNUD = new NumericUpDown();
            MainTLP.SuspendLayout();
            ControlsTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IterationNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KeyNUD).BeginInit();
            SuspendLayout();
            // 
            // MainTLP
            // 
            MainTLP.ColumnCount = 1;
            MainTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTLP.Controls.Add(ControlsTLP, 0, 0);
            MainTLP.Controls.Add(SetBtn, 0, 1);
            MainTLP.Dock = DockStyle.Fill;
            MainTLP.Location = new Point(0, 0);
            MainTLP.Name = "MainTLP";
            MainTLP.RowCount = 2;
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            MainTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            MainTLP.Size = new Size(578, 194);
            MainTLP.TabIndex = 0;
            // 
            // SetBtn
            // 
            SetBtn.Anchor = AnchorStyles.Right;
            SetBtn.Location = new Point(446, 158);
            SetBtn.Margin = new Padding(3, 3, 20, 3);
            SetBtn.Name = "SetBtn";
            SetBtn.Size = new Size(112, 33);
            SetBtn.TabIndex = 0;
            SetBtn.Text = "Set";
            SetBtn.UseVisualStyleBackColor = true;
            SetBtn.Click += SetBtn_Click;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 2;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.58042F));
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.41958F));
            ControlsTLP.Controls.Add(IterationLbl, 0, 1);
            ControlsTLP.Controls.Add(KeyLbl, 0, 0);
            ControlsTLP.Controls.Add(IterationNUD, 1, 1);
            ControlsTLP.Controls.Add(KeyNUD, 1, 0);
            ControlsTLP.Dock = DockStyle.Fill;
            ControlsTLP.Location = new Point(3, 3);
            ControlsTLP.Name = "ControlsTLP";
            ControlsTLP.RowCount = 2;
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ControlsTLP.Size = new Size(572, 149);
            ControlsTLP.TabIndex = 3;
            // 
            // IterationLbl
            // 
            IterationLbl.Anchor = AnchorStyles.Left;
            IterationLbl.AutoSize = true;
            IterationLbl.Location = new Point(3, 99);
            IterationLbl.Name = "IterationLbl";
            IterationLbl.Size = new Size(90, 25);
            IterationLbl.TabIndex = 0;
            IterationLbl.Text = "Iterations:";
            // 
            // KeyLbl
            // 
            KeyLbl.Anchor = AnchorStyles.Left;
            KeyLbl.AutoSize = true;
            KeyLbl.Location = new Point(3, 24);
            KeyLbl.Name = "KeyLbl";
            KeyLbl.Size = new Size(103, 25);
            KeyLbl.TabIndex = 0;
            KeyLbl.Text = "Key Length:";
            // 
            // IterationNUD
            // 
            IterationNUD.Anchor = AnchorStyles.Left;
            IterationNUD.Location = new Point(115, 96);
            IterationNUD.Name = "IterationNUD";
            IterationNUD.Size = new Size(144, 31);
            IterationNUD.TabIndex = 1;
            // 
            // KeyNUD
            // 
            KeyNUD.Anchor = AnchorStyles.Left;
            KeyNUD.Location = new Point(115, 21);
            KeyNUD.Name = "KeyNUD";
            KeyNUD.Size = new Size(144, 31);
            KeyNUD.TabIndex = 1;
            // 
            // OptionsFrm
            // 
            AcceptButton = SetBtn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 194);
            ControlBox = false;
            Controls.Add(MainTLP);
            Name = "OptionsFrm";
            Text = "Configure Your Key!";
            MainTLP.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ControlsTLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IterationNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)KeyNUD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainTLP;
        private Button SetBtn;
        private TableLayoutPanel ControlsTLP;
        private Label IterationLbl;
        private Label KeyLbl;
        private NumericUpDown IterationNUD;
        private NumericUpDown KeyNUD;
    }
}