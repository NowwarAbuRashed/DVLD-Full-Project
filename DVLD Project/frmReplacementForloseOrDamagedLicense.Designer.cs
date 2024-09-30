namespace DVLD_Project
{
    partial class frmReplacementForloseOrDamagedLicense
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
            this.lblTitel = new System.Windows.Forms.Label();
            this.gbRepalcementFor = new System.Windows.Forms.GroupBox();
            this.rbtnLostLicense = new System.Windows.Forms.RadioButton();
            this.rbtnDamagedLicense = new System.Windows.Forms.RadioButton();
            this.gbApplicationInfoforLicenseReplacement = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblRLApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbGendor = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.llblShowNewLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.llblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.ctrlFilterDriverLicenseInfo1 = new DVLD_Project.ctrlFilterDriverLicenseInfo();
            this.gbRepalcementFor.SuspendLayout();
            this.gbApplicationInfoforLicenseReplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitel.Location = new System.Drawing.Point(213, 31);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(415, 28);
            this.lblTitel.TabIndex = 40;
            this.lblTitel.Text = "Replacement for Damaged License";
            // 
            // gbRepalcementFor
            // 
            this.gbRepalcementFor.Controls.Add(this.rbtnLostLicense);
            this.gbRepalcementFor.Controls.Add(this.rbtnDamagedLicense);
            this.gbRepalcementFor.Location = new System.Drawing.Point(524, 74);
            this.gbRepalcementFor.Name = "gbRepalcementFor";
            this.gbRepalcementFor.Size = new System.Drawing.Size(318, 88);
            this.gbRepalcementFor.TabIndex = 41;
            this.gbRepalcementFor.TabStop = false;
            this.gbRepalcementFor.Text = "Repalcement For:";
            // 
            // rbtnLostLicense
            // 
            this.rbtnLostLicense.AutoSize = true;
            this.rbtnLostLicense.Location = new System.Drawing.Point(6, 60);
            this.rbtnLostLicense.Name = "rbtnLostLicense";
            this.rbtnLostLicense.Size = new System.Drawing.Size(103, 21);
            this.rbtnLostLicense.TabIndex = 1;
            this.rbtnLostLicense.TabStop = true;
            this.rbtnLostLicense.Text = "Lost License";
            this.rbtnLostLicense.UseVisualStyleBackColor = true;
            this.rbtnLostLicense.CheckedChanged += new System.EventHandler(this.rbtnLostLicense_CheckedChanged);
            // 
            // rbtnDamagedLicense
            // 
            this.rbtnDamagedLicense.AutoSize = true;
            this.rbtnDamagedLicense.Location = new System.Drawing.Point(6, 33);
            this.rbtnDamagedLicense.Name = "rbtnDamagedLicense";
            this.rbtnDamagedLicense.Size = new System.Drawing.Size(136, 21);
            this.rbtnDamagedLicense.TabIndex = 0;
            this.rbtnDamagedLicense.TabStop = true;
            this.rbtnDamagedLicense.Text = "Damaged License";
            this.rbtnDamagedLicense.UseVisualStyleBackColor = true;
            this.rbtnDamagedLicense.CheckedChanged += new System.EventHandler(this.rbtnDamagedLicense_CheckedChanged);
            // 
            // gbApplicationInfoforLicenseReplacement
            // 
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.btnClose);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.btnRenew);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pictureBox10);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pictureBox7);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label4);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pictureBox3);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblRenewedLicenseID);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label15);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label16);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pictureBox5);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label2);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pictureBox1);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.lblRLApplicationID);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label10);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.label3);
            this.gbApplicationInfoforLicenseReplacement.Controls.Add(this.pbGendor);
            this.gbApplicationInfoforLicenseReplacement.Location = new System.Drawing.Point(12, 579);
            this.gbApplicationInfoforLicenseReplacement.Name = "gbApplicationInfoforLicenseReplacement";
            this.gbApplicationInfoforLicenseReplacement.Size = new System.Drawing.Size(830, 123);
            this.gbApplicationInfoforLicenseReplacement.TabIndex = 42;
            this.gbApplicationInfoforLicenseReplacement.TabStop = false;
            this.gbApplicationInfoforLicenseReplacement.Text = "Application Info for License Replacement";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.cross;
            this.btnClose.Location = new System.Drawing.Point(634, 861);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Image = global::DVLD_Project.Properties.Resources.id_refresh1;
            this.btnRenew.Location = new System.Drawing.Point(760, 861);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(120, 40);
            this.btnRenew.TabIndex = 125;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRenew.UseVisualStyleBackColor = true;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_Project.Properties.Resources.id_refresh;
            this.pictureBox10.Location = new System.Drawing.Point(565, 25);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(19, 21);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 122;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Project.Properties.Resources.field;
            this.pictureBox7.Location = new System.Drawing.Point(181, 29);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(19, 21);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 121;
            this.pictureBox7.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 113;
            this.label4.Text = "Old License ID:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Project.Properties.Resources.id__2_;
            this.pictureBox3.Location = new System.Drawing.Point(565, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 114;
            this.pictureBox3.TabStop = false;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(605, 90);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(28, 16);
            this.lblCreatedBy.TabIndex = 120;
            this.lblCreatedBy.Text = "???";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicenseID.Location = new System.Drawing.Point(606, 64);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(28, 16);
            this.lblOldLicenseID.TabIndex = 119;
            this.lblOldLicenseID.Text = "???";
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(605, 30);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(28, 16);
            this.lblRenewedLicenseID.TabIndex = 118;
            this.lblRenewedLicenseID.Text = "???";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(417, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 16);
            this.label15.TabIndex = 115;
            this.label15.Text = "Created By:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(417, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 16);
            this.label16.TabIndex = 117;
            this.label16.Text = "Renewed License ID:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Project.Properties.Resources.user__8_;
            this.pictureBox5.Location = new System.Drawing.Point(565, 89);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 116;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 105;
            this.label2.Text = "Application Date:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.date;
            this.pictureBox1.Location = new System.Drawing.Point(181, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(221, 90);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(28, 16);
            this.lblApplicationFees.TabIndex = 112;
            this.lblApplicationFees.Text = "???";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationDate.Location = new System.Drawing.Point(222, 59);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(28, 16);
            this.lblApplicationDate.TabIndex = 111;
            this.lblApplicationDate.Text = "???";
            // 
            // lblRLApplicationID
            // 
            this.lblRLApplicationID.AutoSize = true;
            this.lblRLApplicationID.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRLApplicationID.Location = new System.Drawing.Point(221, 29);
            this.lblRLApplicationID.Name = "lblRLApplicationID";
            this.lblRLApplicationID.Size = new System.Drawing.Size(28, 16);
            this.lblRLApplicationID.TabIndex = 110;
            this.lblRLApplicationID.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 107;
            this.label10.Text = "Application Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 109;
            this.label3.Text = "R.L.Application ID:";
            // 
            // pbGendor
            // 
            this.pbGendor.Image = global::DVLD_Project.Properties.Resources.salary;
            this.pbGendor.Location = new System.Drawing.Point(181, 90);
            this.pbGendor.Name = "pbGendor";
            this.pbGendor.Size = new System.Drawing.Size(19, 21);
            this.pbGendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGendor.TabIndex = 108;
            this.pbGendor.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Project.Properties.Resources.cross;
            this.button1.Location = new System.Drawing.Point(546, 708);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 130;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.Image = global::DVLD_Project.Properties.Resources.id_refresh1;
            this.btnIssueReplacement.Location = new System.Drawing.Point(672, 708);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(175, 40);
            this.btnIssueReplacement.TabIndex = 129;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // llblShowNewLicensesInfo
            // 
            this.llblShowNewLicensesInfo.AutoSize = true;
            this.llblShowNewLicensesInfo.Enabled = false;
            this.llblShowNewLicensesInfo.Location = new System.Drawing.Point(216, 721);
            this.llblShowNewLicensesInfo.Name = "llblShowNewLicensesInfo";
            this.llblShowNewLicensesInfo.Size = new System.Drawing.Size(154, 17);
            this.llblShowNewLicensesInfo.TabIndex = 128;
            this.llblShowNewLicensesInfo.TabStop = true;
            this.llblShowNewLicensesInfo.Text = "Show New Licenses Info";
            this.llblShowNewLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowNewLicensesInfo_LinkClicked);
            // 
            // llblShowLicensesHistory
            // 
            this.llblShowLicensesHistory.AutoSize = true;
            this.llblShowLicensesHistory.Enabled = false;
            this.llblShowLicensesHistory.Location = new System.Drawing.Point(38, 720);
            this.llblShowLicensesHistory.Name = "llblShowLicensesHistory";
            this.llblShowLicensesHistory.Size = new System.Drawing.Size(143, 17);
            this.llblShowLicensesHistory.TabIndex = 127;
            this.llblShowLicensesHistory.TabStop = true;
            this.llblShowLicensesHistory.Text = "Show Licenses History";
            this.llblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesHistory_LinkClicked);
            // 
            // ctrlFilterDriverLicenseInfo1
            // 
            this.ctrlFilterDriverLicenseInfo1.Location = new System.Drawing.Point(12, 62);
            this.ctrlFilterDriverLicenseInfo1.Name = "ctrlFilterDriverLicenseInfo1";
            this.ctrlFilterDriverLicenseInfo1.Size = new System.Drawing.Size(835, 511);
            this.ctrlFilterDriverLicenseInfo1.TabIndex = 0;
            // 
            // frmReplacementForloseOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 753);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbApplicationInfoforLicenseReplacement);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.llblShowNewLicensesInfo);
            this.Controls.Add(this.gbRepalcementFor);
            this.Controls.Add(this.llblShowLicensesHistory);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.ctrlFilterDriverLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReplacementForloseOrDamagedLicense";
            this.Text = "Replacement For lose Or Damaged License";
            this.Load += new System.EventHandler(this.frmReplacementForloseOrDamagedLicense_Load);
            this.gbRepalcementFor.ResumeLayout(false);
            this.gbRepalcementFor.PerformLayout();
            this.gbApplicationInfoforLicenseReplacement.ResumeLayout(false);
            this.gbApplicationInfoforLicenseReplacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFilterDriverLicenseInfo ctrlFilterDriverLicenseInfo1;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.GroupBox gbRepalcementFor;
        private System.Windows.Forms.RadioButton rbtnLostLicense;
        private System.Windows.Forms.RadioButton rbtnDamagedLicense;
        private System.Windows.Forms.GroupBox gbApplicationInfoforLicenseReplacement;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblRLApplicationID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbGendor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.LinkLabel llblShowNewLicensesInfo;
        private System.Windows.Forms.LinkLabel llblShowLicensesHistory;
    }
}