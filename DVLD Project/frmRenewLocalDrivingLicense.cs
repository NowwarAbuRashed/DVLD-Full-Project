using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        clsLicenses licenses;
        clsLicenses licensesNew;
        private void FillInDateToApplicationNew()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            lblIssueDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            lblApplicationFees.Text = clsApplicationTypes.Find(2).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.GlobalUser.UserName;
        }
        private void ChickIfCardExpiared(int LicenseID)
        {
            //DataTable dt = clsLicenses.GetAllLicensess();
             licenses = clsLicenses.Find(LicenseID);
            if(licenses.ExpirationDate>DateTime.Now)
            {
                MessageBox.Show($"Select License is not yet expiared, it will expire on: {licenses.ExpirationDate}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = true;
                return;
            }
            btnRenew.Enabled = true;
            llblShowLicensesHistory.Enabled = true;

            lblOldLicenseID.Text = LicenseID.ToString();
            lblLicenseFess.Text = clsLicenseClasses.Find(licenses.LicenseClass).ClassFees.ToString();
            lblApplicationFees.Text = clsApplicationTypes.Find(2).Fees.ToString();
            lblTotalFees.Text =  (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal( lblLicenseFess.Text)).ToString();
            lblExpirationDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");

        }
        private void _ButtonClickedHandler(object sender, EventArgs e)
        {
            if(ctrlFilterDriverLicenseInfo1.GetLicenseID()==0)
            {
                btnRenew.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                return;
            }
            ChickIfCardExpiared(ctrlFilterDriverLicenseInfo1.GetLicenseID());
        }
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            FillInDateToApplicationNew();
            ctrlFilterDriverLicenseInfo1.ButtonClicked += _ButtonClickedHandler;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = ctrlFilterDriverLicenseInfo1.GetLicenseID();
            int ApplicationID = clsLicenses.Find(LicenseID).ApplicationID;
            DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            foreach (DataRow row in dt.Rows)
            {
                if (ApplicationID == Convert.ToInt32(row["ApplicationID"].ToString()))
                {
                    frmLicenseHistory licenseHistory = new frmLicenseHistory(Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()));
                    licenseHistory.ShowDialog();
                    break;
                }


            }
        }

        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseInfo licenseInfo = new frmLicenseInfo(licensesNew.ID);
            licenseInfo.ShowDialog();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the liecese?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                try
                {
                    clsApplications applicationsOld = clsApplications.Find(licenses.ApplicationID);
                    clsApplications applicationsNew = new clsApplications();

                    applicationsNew.ApplicationPersonID = applicationsOld.ApplicationPersonID;
                    applicationsNew.ApplicationDate = DateTime.Now;
                    applicationsNew.ApplicationTypeID = clsApplicationTypes.Find(2).ID;
                    applicationsNew.ApplicationStatus = 3;
                    applicationsNew.lastStatusDate = DateTime.Now;
                    applicationsNew.PaidFees = clsApplicationTypes.Find(applicationsNew.ApplicationTypeID).Fees;
                    applicationsNew.CreatedByUserID = clsGlobal.GlobalUser.ID;

                    applicationsNew.Save();


                    licensesNew = new clsLicenses();

                    licensesNew.ApplicationID = applicationsNew.ID;
                    licensesNew.DriverID = licenses.DriverID;
                    licensesNew.LicenseClass = licenses.LicenseClass;
                    licensesNew.IssueDate = DateTime.Now;
                    licensesNew.ExpirationDate = licensesNew.IssueDate.AddYears(10);
                    licensesNew.Notes = txtNotes.Text;
                    licensesNew.PaidFees = Convert.ToDecimal(lblLicenseFess.Text);

                    licenses.IsActive = false;

                    licensesNew.IsActive = true;
                    licensesNew.IssueReason = applicationsNew.ApplicationTypeID;
                    licensesNew.CreatedByUserID = clsGlobal.GlobalUser.ID;

                    licenses.Save();

                    licensesNew.Save();

                    clsLocalDrivingLicenseApplications localDrivingLicenseApplicationsNew = new clsLocalDrivingLicenseApplications();
                    localDrivingLicenseApplicationsNew.ApplicationID = applicationsNew.ID;
                    localDrivingLicenseApplicationsNew.LicenseClassID = licensesNew.LicenseClass;

                    localDrivingLicenseApplicationsNew.Save();

                    MessageBox.Show($"Licensed Renewed Successfully with ID={licensesNew.ID}");
                    lblRenewedLicenseID.Text= licensesNew.ID.ToString();
                    lblRLApplicationID.Text=applicationsNew.ID.ToString();
                    llblShowLicensesHistory.Enabled = true;
                    llblShowNewLicensesInfo.Enabled = true;
                    btnRenew.Enabled = false;

                }
                catch(Exception ex)
                {

                }

            }




        }

        private void ctrlFilterDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
