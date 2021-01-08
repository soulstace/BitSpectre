namespace BitSpectre
{
    partial class frmSpectre
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.labelDecimalValue = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.linkLabelMicrosoft = new System.Windows.Forms.LinkLabel();
            this.checkBoxUnderstood = new System.Windows.Forms.CheckBox();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.checkBoxHyperV = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Enabled = false;
            this.checkedListBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox1.Items.AddRange(new object[] {
            "0 (0) Enable mitigations for CVE-2017-5715 (Spectre Variant 2) and CVE-2017-5754 " +
                "(Meltdown)",
            "1 (1) Disable Variant 2: (CVE-2017-5715  \"Branch Target Injection\") mitigation",
            "2 (2) Disable mitigations for CVE-2017-5715 (Spectre Variant 2) and CVE-2017-5754" +
                " (Meltdown) (use 1+2 to disable fully)",
            "3 (4)",
            "4 (8) Enable mitigations for CVE-2018-3639 (Speculative Store Bypass), CVE-2017-5" +
                "715 (Spectre Variant 2), and CVE-2017-5754 (Meltdown)",
            "5 (16)",
            "6 (32)",
            "7 (64) Enable user-to-kernel protection on AMD processors along with other protec" +
                "tions for Spectre Variant 2 (add +8 for AMD/Intel Full)",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14 (8192) Intel® TSX Transaction Asynchronous Abort Microarchitectural Data Sampl" +
                "ing, Spectre, Meltdown, Speculative Store Bypass Disable, L1 Terminal Fault, w/H" +
                "T disabled (+72=8264)"});
            this.checkedListBox1.Location = new System.Drawing.Point(5, 25);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(1333, 293);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // labelDecimalValue
            // 
            this.labelDecimalValue.AutoSize = true;
            this.labelDecimalValue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDecimalValue.Location = new System.Drawing.Point(8, 324);
            this.labelDecimalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDecimalValue.Name = "labelDecimalValue";
            this.labelDecimalValue.Size = new System.Drawing.Size(106, 17);
            this.labelDecimalValue.TabIndex = 5;
            this.labelDecimalValue.Text = "Decimal Value: ";
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelHelp.Location = new System.Drawing.Point(5, 5);
            this.labelHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(161, 17);
            this.labelHelp.TabIndex = 3;
            this.labelHelp.Text = "Bit # (Value) Description";
            // 
            // linkLabelMicrosoft
            // 
            this.linkLabelMicrosoft.AutoSize = true;
            this.linkLabelMicrosoft.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.linkLabelMicrosoft.Location = new System.Drawing.Point(1032, 4);
            this.linkLabelMicrosoft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelMicrosoft.Name = "linkLabelMicrosoft";
            this.linkLabelMicrosoft.Size = new System.Drawing.Size(215, 17);
            this.linkLabelMicrosoft.TabIndex = 1;
            this.linkLabelMicrosoft.TabStop = true;
            this.linkLabelMicrosoft.Text = "View Microsoft\'s reference article";
            this.linkLabelMicrosoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMicrosoft_LinkClicked);
            // 
            // checkBoxUnderstood
            // 
            this.checkBoxUnderstood.AutoSize = true;
            this.checkBoxUnderstood.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUnderstood.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxUnderstood.Location = new System.Drawing.Point(388, 4);
            this.checkBoxUnderstood.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUnderstood.Name = "checkBoxUnderstood";
            this.checkBoxUnderstood.Size = new System.Drawing.Size(476, 21);
            this.checkBoxUnderstood.TabIndex = 2;
            this.checkBoxUnderstood.Text = "If you know what you\'re doing and understand the risks, check here -->";
            this.checkBoxUnderstood.UseVisualStyleBackColor = true;
            this.checkBoxUnderstood.CheckedChanged += new System.EventHandler(this.checkBoxUnderstood_CheckedChanged);
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.linkLabelGitHub.Location = new System.Drawing.Point(1084, 324);
            this.linkLabelGitHub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(152, 17);
            this.linkLabelGitHub.TabIndex = 0;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "View project on GitHub";
            this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // checkBoxHyperV
            // 
            this.checkBoxHyperV.AutoSize = true;
            this.checkBoxHyperV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHyperV.Enabled = false;
            this.checkBoxHyperV.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxHyperV.Location = new System.Drawing.Point(520, 324);
            this.checkBoxHyperV.Name = "checkBoxHyperV";
            this.checkBoxHyperV.Size = new System.Drawing.Size(285, 21);
            this.checkBoxHyperV.TabIndex = 6;
            this.checkBoxHyperV.Text = "Apply mitigations to Hyper-V (if installed)";
            this.checkBoxHyperV.UseVisualStyleBackColor = true;
            this.checkBoxHyperV.CheckedChanged += new System.EventHandler(this.checkBoxHyperV_CheckedChanged);
            // 
            // frmSpectre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1343, 350);
            this.Controls.Add(this.checkBoxHyperV);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.linkLabelGitHub);
            this.Controls.Add(this.checkBoxUnderstood);
            this.Controls.Add(this.linkLabelMicrosoft);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelDecimalValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSpectre";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speculative execution side-channel vulnerability mitigations - Bit Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpectre_FormClosing);
            this.Load += new System.EventHandler(this.frmSpectre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label labelDecimalValue;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.LinkLabel linkLabelMicrosoft;
        private System.Windows.Forms.CheckBox checkBoxUnderstood;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
        private System.Windows.Forms.CheckBox checkBoxHyperV;
    }
}