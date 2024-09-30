namespace DVLD_Project
{
    partial class frmListInternationalLicenseApplication
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
            this.txtFiler = new System.Windows.Forms.TextBox();
            this.cmpFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddInterationalLicenseApplications = new System.Windows.Forms.Button();
            this.dgvShowAllInternationalLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cmtInternationalLicenseApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbFilterActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAllInternationalLicenseApplications)).BeginInit();
            this.cmtInternationalLicenseApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiler
            // 
            this.txtFiler.Location = new System.Drawing.Point(266, 249);
            this.txtFiler.Name = "txtFiler";
            this.txtFiler.Size = new System.Drawing.Size(185, 24);
            this.txtFiler.TabIndex = 13;
            this.txtFiler.Visible = false;
            this.txtFiler.TextChanged += new System.EventHandler(this.txtFiler_TextChanged);
            this.txtFiler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiler_KeyPress);
            // 
            // cmpFilterBy
            // 
            this.cmpFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmpFilterBy.FormattingEnabled = true;
            this.cmpFilterBy.Items.AddRange(new object[] {
            "None",
            "Int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID",
            "Is Active"});
            this.cmpFilterBy.Location = new System.Drawing.Point(98, 249);
            this.cmpFilterBy.Name = "cmpFilterBy";
            this.cmpFilterBy.Size = new System.Drawing.Size(162, 24);
            this.cmpFilterBy.TabIndex = 12;
            this.cmpFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmpFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filyer By:";
            // 
            // btnAddInterationalLicenseApplications
            // 
            this.btnAddInterationalLicenseApplications.Image = global::DVLD_Project.Properties.Resources.papers;
            this.btnAddInterationalLicenseApplications.Location = new System.Drawing.Point(1169, 199);
            this.btnAddInterationalLicenseApplications.Name = "btnAddInterationalLicenseApplications";
            this.btnAddInterationalLicenseApplications.Size = new System.Drawing.Size(75, 74);
            this.btnAddInterationalLicenseApplications.TabIndex = 10;
            this.btnAddInterationalLicenseApplications.UseVisualStyleBackColor = true;
            this.btnAddInterationalLicenseApplications.Click += new System.EventHandler(this.btnAddInterationalLicenseApplications_Click);
            // 
            // dgvShowAllInternationalLicenseApplications
            // 
            this.dgvShowAllInternationalLicenseApplications.AllowUserToAddRows = false;
            this.dgvShowAllInternationalLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvShowAllInternationalLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowAllInternationalLicenseApplications.ContextMenuStrip = this.cmtInternationalLicenseApplication;
            this.dgvShowAllInternationalLicenseApplications.Location = new System.Drawing.Point(15, 279);
            this.dgvShowAllInternationalLicenseApplications.Name = "dgvShowAllInternationalLicenseApplications";
            this.dgvShowAllInternationalLicenseApplications.ReadOnly = true;
            this.dgvShowAllInternationalLicenseApplications.RowHeadersWidth = 51;
            this.dgvShowAllInternationalLicenseApplications.RowTemplate.Height = 26;
            this.dgvShowAllInternationalLicenseApplications.Size = new System.Drawing.Size(1229, 265);
            this.dgvShowAllInternationalLicenseApplications.TabIndex = 9;
            this.dgvShowAllInternationalLicenseApplications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowAllInternationalLicenseApplications_CellContentClick);
            // 
            // cmtInternationalLicenseApplication
            // 
            this.cmtInternationalLicenseApplication.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmtInternationalLicenseApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmtInternationalLicenseApplication.Name = "cmtInternationalLicenseApplication";
            this.cmtInternationalLicenseApplication.Size = new System.Drawing.Size(282, 124);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(379, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "International License Application";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.repetitive_tasks;
            this.pictureBox1.Location = new System.Drawing.Point(485, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 53;
            this.label4.Text = "# Records : ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(123, 562);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(29, 17);
            this.lblRecords.TabIndex = 52;
            this.lblRecords.Text = "???";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.cross;
            this.btnClose.Location = new System.Drawing.Point(1124, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbFilterActive
            // 
            this.cbFilterActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterActive.FormattingEnabled = true;
            this.cbFilterActive.Items.AddRange(new object[] {
            "None",
            "Yes",
            "No"});
            this.cbFilterActive.Location = new System.Drawing.Point(266, 249);
            this.cbFilterActive.Name = "cbFilterActive";
            this.cbFilterActive.Size = new System.Drawing.Size(121, 24);
            this.cbFilterActive.TabIndex = 54;
            this.cbFilterActive.Visible = false;
            this.cbFilterActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterActive_SelectedIndexChanged);
            // 
            // frmListInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 594);
            this.Controls.Add(this.cbFilterActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFiler);
            this.Controls.Add(this.cmpFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddInterationalLicenseApplications);
            this.Controls.Add(this.dgvShowAllInternationalLicenseApplications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmListInternationalLicenseApplication";
            this.Text = "List International License Application";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAllInternationalLicenseApplications)).EndInit();
            this.cmtInternationalLicenseApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiler;
        private System.Windows.Forms.ComboBox cmpFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddInterationalLicenseApplications;
        private System.Windows.Forms.DataGridView dgvShowAllInternationalLicenseApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilterActive;
        private System.Windows.Forms.ContextMenuStrip cmtInternationalLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}