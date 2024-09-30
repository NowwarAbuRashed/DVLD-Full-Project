namespace DVLD_Project
{
    partial class frmListDetainedLicenses
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.cbFilterActive = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmpFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvShowAllDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmtDetaindLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAllDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmtDetaindLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 586);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 61;
            this.label4.Text = "# Records : ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(114, 586);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(29, 17);
            this.lblRecords.TabIndex = 60;
            this.lblRecords.Text = "???";
            // 
            // cbFilterActive
            // 
            this.cbFilterActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterActive.FormattingEnabled = true;
            this.cbFilterActive.Items.AddRange(new object[] {
            "None",
            "Yes",
            "No"});
            this.cbFilterActive.Location = new System.Drawing.Point(265, 276);
            this.cbFilterActive.Name = "cbFilterActive";
            this.cbFilterActive.Size = new System.Drawing.Size(121, 24);
            this.cbFilterActive.TabIndex = 58;
            this.cbFilterActive.Visible = false;
            this.cbFilterActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterActive_SelectedIndexChanged_1);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(264, 275);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(185, 24);
            this.txtFilter.TabIndex = 57;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged_1);
            // 
            // cmpFilterBy
            // 
            this.cmpFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmpFilterBy.FormattingEnabled = true;
            this.cmpFilterBy.Items.AddRange(new object[] {
            "None",
            "D.ID",
            "L.ID",
            "D.Date",
            "Is Relesed",
            "N.No",
            "Full Name"});
            this.cmpFilterBy.Location = new System.Drawing.Point(96, 275);
            this.cmpFilterBy.Name = "cmpFilterBy";
            this.cmpFilterBy.Size = new System.Drawing.Size(162, 24);
            this.cmpFilterBy.TabIndex = 56;
            this.cmpFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmpFilterBy_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Filyer By:";
            // 
            // dgvShowAllDetainedLicenses
            // 
            this.dgvShowAllDetainedLicenses.AllowUserToAddRows = false;
            this.dgvShowAllDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvShowAllDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowAllDetainedLicenses.ContextMenuStrip = this.cmtDetaindLicenses;
            this.dgvShowAllDetainedLicenses.Location = new System.Drawing.Point(12, 305);
            this.dgvShowAllDetainedLicenses.Name = "dgvShowAllDetainedLicenses";
            this.dgvShowAllDetainedLicenses.ReadOnly = true;
            this.dgvShowAllDetainedLicenses.RowHeadersWidth = 51;
            this.dgvShowAllDetainedLicenses.RowTemplate.Height = 26;
            this.dgvShowAllDetainedLicenses.Size = new System.Drawing.Size(1192, 265);
            this.dgvShowAllDetainedLicenses.TabIndex = 53;
            this.dgvShowAllDetainedLicenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowAllDetainedLicenses_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 28);
            this.label1.TabIndex = 52;
            this.label1.Text = "Manage Users";
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.Image = global::DVLD_Project.Properties.Resources.hand__3_;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1048, 237);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(75, 63);
            this.btnReleaseDetainedLicense.TabIndex = 62;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.cross;
            this.btnClose.Location = new System.Drawing.Point(1084, 574);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Image = global::DVLD_Project.Properties.Resources.hand;
            this.btnDetainLicense.Location = new System.Drawing.Point(1129, 236);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(75, 63);
            this.btnDetainLicense.TabIndex = 54;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.hand;
            this.pictureBox1.Location = new System.Drawing.Point(513, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // cmtDetaindLicenses
            // 
            this.cmtDetaindLicenses.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmtDetaindLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.cmtDetaindLicenses.Name = "cmtDetaindLicenses";
            this.cmtDetaindLicenses.Size = new System.Drawing.Size(282, 192);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.view_details1;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(281, 40);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.id_search;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(281, 40);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.user_id_clock__2_;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(281, 40);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.hand__2_;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(281, 40);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 615);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterActive);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmpFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.dgvShowAllDetainedLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListDetainedLicenses";
            this.Text = "List Detained Licenses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAllDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmtDetaindLicenses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilterActive;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cmpFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.DataGridView dgvShowAllDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.ContextMenuStrip cmtDetaindLicenses;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}