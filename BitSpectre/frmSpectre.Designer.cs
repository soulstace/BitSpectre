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
            this.components = new System.ComponentModel.Container();
            this.clbox = new System.Windows.Forms.CheckedListBox();
            this.lbDecimal = new System.Windows.Forms.Label();
            this.lbHelp = new System.Windows.Forms.Label();
            this.lbMS = new System.Windows.Forms.LinkLabel();
            this.cbUnderstood = new System.Windows.Forms.CheckBox();
            this.lbGitHub = new System.Windows.Forms.LinkLabel();
            this.cbHyperV = new System.Windows.Forms.CheckBox();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miJump = new System.Windows.Forms.ToolStripMenuItem();
            this.miSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.miTools = new System.Windows.Forms.ToolStripMenuItem();
            this.miCertificates = new System.Windows.Forms.ToolStripMenuItem();
            this.miLsStores = new System.Windows.Forms.ToolStripMenuItem();
            this.miRecurse = new System.Windows.Forms.ToolStripMenuItem();
            this.miComputerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetDNS = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetExecutionPolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetMMAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.miPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetAppx = new System.Windows.Forms.ToolStripMenuItem();
            this.miStdPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.miProcMitigation = new System.Windows.Forms.ToolStripMenuItem();
            this.miFullPolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.miSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSchedTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetService = new System.Windows.Forms.ToolStripMenuItem();
            this.miSMB = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetSmbSession = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetSmbShare = new System.Windows.Forms.ToolStripMenuItem();
            this.miTPM = new System.Windows.Forms.ToolStripMenuItem();
            this.miSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.miVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMenu = new System.Windows.Forms.LinkLabel();
            this.tphv = new BitSpectre.TPanel();
            this.cms1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbox
            // 
            this.clbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.clbox.CheckOnClick = true;
            this.clbox.Enabled = false;
            this.clbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clbox.Items.AddRange(new object[] {
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
            this.clbox.Location = new System.Drawing.Point(4, 20);
            this.clbox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clbox.Name = "clbox";
            this.clbox.Size = new System.Drawing.Size(932, 229);
            this.clbox.TabIndex = 4;
            this.clbox.SelectedIndexChanged += new System.EventHandler(this.clbox_SelectedIndexChanged);
            // 
            // lbDecimal
            // 
            this.lbDecimal.AutoSize = true;
            this.lbDecimal.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDecimal.Location = new System.Drawing.Point(4, 252);
            this.lbDecimal.Name = "lbDecimal";
            this.lbDecimal.Size = new System.Drawing.Size(81, 13);
            this.lbDecimal.TabIndex = 5;
            this.lbDecimal.Text = "Decimal Value: ";
            this.lbDecimal.DoubleClick += new System.EventHandler(this.lbDecimal_DoubleClick);
            // 
            // lbHelp
            // 
            this.lbHelp.AutoSize = true;
            this.lbHelp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHelp.Location = new System.Drawing.Point(4, 4);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(121, 13);
            this.lbHelp.TabIndex = 3;
            this.lbHelp.Text = "Bit # (Value) Description";
            // 
            // lbMS
            // 
            this.lbMS.AutoSize = true;
            this.lbMS.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lbMS.Location = new System.Drawing.Point(772, 4);
            this.lbMS.Name = "lbMS";
            this.lbMS.Size = new System.Drawing.Size(162, 13);
            this.lbMS.TabIndex = 1;
            this.lbMS.TabStop = true;
            this.lbMS.Text = "View Microsoft\'s reference article";
            this.lbMS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMS_LinkClicked);
            // 
            // cbUnderstood
            // 
            this.cbUnderstood.AutoSize = true;
            this.cbUnderstood.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUnderstood.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbUnderstood.Location = new System.Drawing.Point(284, 3);
            this.cbUnderstood.Name = "cbUnderstood";
            this.cbUnderstood.Size = new System.Drawing.Size(361, 17);
            this.cbUnderstood.TabIndex = 2;
            this.cbUnderstood.Text = "If you know what you\'re doing and understand the risks, check here -->";
            this.cbUnderstood.UseVisualStyleBackColor = true;
            this.cbUnderstood.CheckedChanged += new System.EventHandler(this.cbUnderstood_CheckedChanged);
            // 
            // lbGitHub
            // 
            this.lbGitHub.AutoSize = true;
            this.lbGitHub.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lbGitHub.Location = new System.Drawing.Point(820, 252);
            this.lbGitHub.Name = "lbGitHub";
            this.lbGitHub.Size = new System.Drawing.Size(116, 13);
            this.lbGitHub.TabIndex = 0;
            this.lbGitHub.TabStop = true;
            this.lbGitHub.Text = "View project on GitHub";
            this.lbGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbGitHub_LinkClicked);
            // 
            // cbHyperV
            // 
            this.cbHyperV.AutoSize = true;
            this.cbHyperV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbHyperV.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbHyperV.Location = new System.Drawing.Point(368, 251);
            this.cbHyperV.Margin = new System.Windows.Forms.Padding(2);
            this.cbHyperV.Name = "cbHyperV";
            this.cbHyperV.Size = new System.Drawing.Size(212, 17);
            this.cbHyperV.TabIndex = 6;
            this.cbHyperV.TabStop = false;
            this.cbHyperV.Text = "Apply mitigations to Hyper-V (if installed)";
            this.cbHyperV.UseVisualStyleBackColor = true;
            this.cbHyperV.CheckedChanged += new System.EventHandler(this.checkBoxHyperV_CheckedChanged);
            // 
            // cms1
            // 
            this.cms1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cms1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miJump,
            this.miSep1,
            this.miDelete,
            this.miSep2,
            this.miTools,
            this.miSep3,
            this.miVersion});
            this.cms1.Name = "cm1";
            this.cms1.Size = new System.Drawing.Size(140, 110);
            this.cms1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cms1_Closed);
            this.cms1.Opening += new System.ComponentModel.CancelEventHandler(this.cms1_Opening);
            // 
            // miJump
            // 
            this.miJump.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miJump.Name = "miJump";
            this.miJump.Size = new System.Drawing.Size(139, 22);
            this.miJump.Text = "&Jump to Key";
            this.miJump.Click += new System.EventHandler(this.miJump_Click);
            // 
            // miSep1
            // 
            this.miSep1.Name = "miSep1";
            this.miSep1.Size = new System.Drawing.Size(136, 6);
            // 
            // miDelete
            // 
            this.miDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(139, 22);
            this.miDelete.Text = "Delete All";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // miSep2
            // 
            this.miSep2.Name = "miSep2";
            this.miSep2.Size = new System.Drawing.Size(136, 6);
            // 
            // miTools
            // 
            this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCertificates,
            this.miComputerInfo,
            this.miGetDNS,
            this.miGetExecutionPolicy,
            this.miGetMMAgent,
            this.miPackages,
            this.miGetProcess,
            this.miProcMitigation,
            this.miSchedTasks,
            this.miGetService,
            this.miSMB,
            this.miTPM});
            this.miTools.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miTools.Name = "miTools";
            this.miTools.Size = new System.Drawing.Size(139, 22);
            this.miTools.Text = "&Tools";
            // 
            // miCertificates
            // 
            this.miCertificates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLsStores,
            this.miRecurse});
            this.miCertificates.Name = "miCertificates";
            this.miCertificates.Size = new System.Drawing.Size(172, 22);
            this.miCertificates.Text = "Certificates";
            // 
            // miLsStores
            // 
            this.miLsStores.Name = "miLsStores";
            this.miLsStores.Size = new System.Drawing.Size(127, 22);
            this.miLsStores.Text = "List Stores";
            this.miLsStores.Click += new System.EventHandler(this.miLsStores_Click);
            // 
            // miRecurse
            // 
            this.miRecurse.Name = "miRecurse";
            this.miRecurse.Size = new System.Drawing.Size(127, 22);
            this.miRecurse.Text = "Recursive";
            this.miRecurse.Click += new System.EventHandler(this.miRecurse_Click);
            // 
            // miComputerInfo
            // 
            this.miComputerInfo.Name = "miComputerInfo";
            this.miComputerInfo.Size = new System.Drawing.Size(172, 22);
            this.miComputerInfo.Text = "Computer Info";
            this.miComputerInfo.Click += new System.EventHandler(this.miComputerInfo_Click);
            // 
            // miGetDNS
            // 
            this.miGetDNS.Name = "miGetDNS";
            this.miGetDNS.Size = new System.Drawing.Size(172, 22);
            this.miGetDNS.Text = "DNS Client Cache";
            this.miGetDNS.Click += new System.EventHandler(this.miGetDNS_Click);
            // 
            // miGetExecutionPolicy
            // 
            this.miGetExecutionPolicy.Name = "miGetExecutionPolicy";
            this.miGetExecutionPolicy.Size = new System.Drawing.Size(172, 22);
            this.miGetExecutionPolicy.Text = "Execution Policy";
            this.miGetExecutionPolicy.Click += new System.EventHandler(this.miGetExecutionPolicy_Click);
            // 
            // miGetMMAgent
            // 
            this.miGetMMAgent.Name = "miGetMMAgent";
            this.miGetMMAgent.Size = new System.Drawing.Size(172, 22);
            this.miGetMMAgent.Text = "MMAgent";
            this.miGetMMAgent.Click += new System.EventHandler(this.miGetMMAgent_Click);
            // 
            // miPackages
            // 
            this.miPackages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGetAppx,
            this.miStdPackages});
            this.miPackages.Name = "miPackages";
            this.miPackages.Size = new System.Drawing.Size(172, 22);
            this.miPackages.Text = "Packages";
            // 
            // miGetAppx
            // 
            this.miGetAppx.Name = "miGetAppx";
            this.miGetAppx.Size = new System.Drawing.Size(121, 22);
            this.miGetAppx.Text = "Appx";
            this.miGetAppx.Click += new System.EventHandler(this.miGetAppx_Click);
            // 
            // miStdPackages
            // 
            this.miStdPackages.Name = "miStdPackages";
            this.miStdPackages.Size = new System.Drawing.Size(121, 22);
            this.miStdPackages.Text = "Standard";
            this.miStdPackages.Click += new System.EventHandler(this.miStdPackages_Click);
            // 
            // miGetProcess
            // 
            this.miGetProcess.Name = "miGetProcess";
            this.miGetProcess.Size = new System.Drawing.Size(172, 22);
            this.miGetProcess.Text = "Processes";
            this.miGetProcess.Click += new System.EventHandler(this.miGetProcess_Click);
            // 
            // miProcMitigation
            // 
            this.miProcMitigation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFullPolicy,
            this.miSystem});
            this.miProcMitigation.Name = "miProcMitigation";
            this.miProcMitigation.Size = new System.Drawing.Size(172, 22);
            this.miProcMitigation.Text = "Process Mitigation";
            // 
            // miFullPolicy
            // 
            this.miFullPolicy.Name = "miFullPolicy";
            this.miFullPolicy.Size = new System.Drawing.Size(128, 22);
            this.miFullPolicy.Text = "Full Policy";
            this.miFullPolicy.Click += new System.EventHandler(this.miFullPolicy_Click);
            // 
            // miSystem
            // 
            this.miSystem.Name = "miSystem";
            this.miSystem.Size = new System.Drawing.Size(128, 22);
            this.miSystem.Text = "System";
            this.miSystem.Click += new System.EventHandler(this.miSystem_Click);
            // 
            // miSchedTasks
            // 
            this.miSchedTasks.Name = "miSchedTasks";
            this.miSchedTasks.Size = new System.Drawing.Size(172, 22);
            this.miSchedTasks.Text = "Scheduled Tasks";
            this.miSchedTasks.Click += new System.EventHandler(this.miSchedTasks_Click);
            // 
            // miGetService
            // 
            this.miGetService.Name = "miGetService";
            this.miGetService.Size = new System.Drawing.Size(172, 22);
            this.miGetService.Text = "Services";
            this.miGetService.Click += new System.EventHandler(this.miGetService_Click);
            // 
            // miSMB
            // 
            this.miSMB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGetSmbSession,
            this.miGetSmbShare});
            this.miSMB.Name = "miSMB";
            this.miSMB.Size = new System.Drawing.Size(172, 22);
            this.miSMB.Text = "SMB";
            // 
            // miGetSmbSession
            // 
            this.miGetSmbSession.Name = "miGetSmbSession";
            this.miGetSmbSession.Size = new System.Drawing.Size(118, 22);
            this.miGetSmbSession.Text = "Sessions";
            this.miGetSmbSession.Click += new System.EventHandler(this.miGetSmbSession_Click);
            // 
            // miGetSmbShare
            // 
            this.miGetSmbShare.Name = "miGetSmbShare";
            this.miGetSmbShare.Size = new System.Drawing.Size(118, 22);
            this.miGetSmbShare.Text = "Shares";
            this.miGetSmbShare.Click += new System.EventHandler(this.miGetSmbShare_Click_1);
            // 
            // miTPM
            // 
            this.miTPM.Name = "miTPM";
            this.miTPM.Size = new System.Drawing.Size(172, 22);
            this.miTPM.Text = "TPM";
            this.miTPM.Click += new System.EventHandler(this.miTPM_Click);
            // 
            // miSep3
            // 
            this.miSep3.Name = "miSep3";
            this.miSep3.Size = new System.Drawing.Size(136, 6);
            // 
            // miVersion
            // 
            this.miVersion.ForeColor = System.Drawing.Color.Gray;
            this.miVersion.Name = "miVersion";
            this.miVersion.Size = new System.Drawing.Size(139, 22);
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lbMenu.Location = new System.Drawing.Point(200, 252);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(86, 13);
            this.lbMenu.TabIndex = 9;
            this.lbMenu.TabStop = true;
            this.lbMenu.Text = "Advanced Menu";
            this.lbMenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMenu_LinkClicked);
            // 
            // tphv
            // 
            this.tphv.Location = new System.Drawing.Point(332, 248);
            this.tphv.Margin = new System.Windows.Forms.Padding(2);
            this.tphv.Name = "tphv";
            this.tphv.Size = new System.Drawing.Size(288, 24);
            this.tphv.TabIndex = 7;
            // 
            // frmSpectre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(941, 271);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.tphv);
            this.Controls.Add(this.cbHyperV);
            this.Controls.Add(this.clbox);
            this.Controls.Add(this.lbGitHub);
            this.Controls.Add(this.cbUnderstood);
            this.Controls.Add(this.lbMS);
            this.Controls.Add(this.lbHelp);
            this.Controls.Add(this.lbDecimal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSpectre";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speculative execution side-channel vulnerability mitigations - Bit Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSpectre_FormClosing);
            this.Load += new System.EventHandler(this.frmSpectre_Load);
            this.cms1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbox;
        private System.Windows.Forms.Label lbDecimal;
        private System.Windows.Forms.Label lbHelp;
        private System.Windows.Forms.LinkLabel lbMS;
        private System.Windows.Forms.CheckBox cbUnderstood;
        private System.Windows.Forms.LinkLabel lbGitHub;
        private System.Windows.Forms.CheckBox cbHyperV;
        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ToolStripMenuItem miJump;
        private System.Windows.Forms.ToolStripSeparator miSep1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private TPanel tphv;
        private System.Windows.Forms.ToolStripSeparator miSep2;
        private System.Windows.Forms.ToolStripMenuItem miVersion;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStripMenuItem miProcMitigation;
        private System.Windows.Forms.ToolStripMenuItem miFullPolicy;
        private System.Windows.Forms.ToolStripMenuItem miSystem;
        private System.Windows.Forms.ToolStripMenuItem miCertificates;
        private System.Windows.Forms.ToolStripMenuItem miRecurse;
        private System.Windows.Forms.ToolStripSeparator miSep3;
        private System.Windows.Forms.ToolStripMenuItem miLsStores;
        private System.Windows.Forms.ToolStripMenuItem miGetMMAgent;
        private System.Windows.Forms.ToolStripMenuItem miGetExecutionPolicy;
        private System.Windows.Forms.ToolStripMenuItem miGetProcess;
        private System.Windows.Forms.ToolStripMenuItem miGetService;
        private System.Windows.Forms.ToolStripMenuItem miGetDNS;
        private System.Windows.Forms.ToolStripMenuItem miComputerInfo;
        private System.Windows.Forms.ToolStripMenuItem miTPM;
        private System.Windows.Forms.ToolStripMenuItem miPackages;
        private System.Windows.Forms.ToolStripMenuItem miSMB;
        private System.Windows.Forms.ToolStripMenuItem miGetSmbShare;
        private System.Windows.Forms.ToolStripMenuItem miGetSmbSession;
        private System.Windows.Forms.ToolStripMenuItem miGetAppx;
        private System.Windows.Forms.ToolStripMenuItem miStdPackages;
        private System.Windows.Forms.ToolStripMenuItem miSchedTasks;
        private System.Windows.Forms.LinkLabel lbMenu;
    }
}