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
    public partial class frmReplacementForloseOrDamagedLicense : Form
    {
        clsLicenses licenses;
        clsLicenses licensesNew;
        private void FillInDateToApplicationNew()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            if (rbtnLostLicense.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.Find(3).Fees.ToString();
            }
            else
            {
                lblApplicationFees.Text = clsApplicationTypes.Find(4).Fees.ToString();
            }
            lblCreatedBy.Text = clsGlobal.GlobalUser.UserName;
        }
        private void ChickIfCardIsActive(int LicenseID)
        {
            
            licenses = clsLicenses.Find(LicenseID);
            if (!licenses.IsActive)
            {
                MessageBox.Show($"Selected License is Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = true;
                return;
            }
            btnIssueReplacement.Enabled = true;
            llblShowLicensesHistory.Enabled = true;

            lblOldLicenseID.Text = LicenseID.ToString();
            

        }
        private void _ButtonClickedHandler(object sender, EventArgs e)
        {
            if (ctrlFilterDriverLicenseInfo1.GetLicenseID() == 0)
            {
                btnIssueReplacement.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                return;
            }
            ChickIfCardIsActive(ctrlFilterDriverLicenseInfo1.GetLicenseID());
        }
        public frmReplacementForloseOrDamagedLicense()
        {
            InitializeComponent();
            rbtnDamagedLicense.Checked = true;
            FillInDateToApplicationNew();
            ctrlFilterDriverLicenseInfo1.ButtonClicked += _ButtonClickedHandler;
        }

        private void frmReplacementForloseOrDamagedLicense_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the liecese?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    clsApplications applicationsOld = clsApplications.Find(licenses.ApplicationID);
                    clsApplications applicationsNew = new clsApplications();

                    applicationsNew.ApplicationPersonID = applicationsOld.ApplicationPersonID;
                    applicationsNew.ApplicationDate = DateTime.Now;
                    if (rbtnLostLicense.Checked)
                    {
                        applicationsNew.ApplicationTypeID = clsApplicationTypes.Find(3).ID;
                    }
                    else
                    {
                        applicationsNew.ApplicationTypeID = clsApplicationTypes.Find(4).ID;
                    }
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
                    licensesNew.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);

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
                    lblRenewedLicenseID.Text = licensesNew.ID.ToString();
                    lblRLApplicationID.Text = applicationsNew.ID.ToString();
                    llblShowLicensesHistory.Enabled = true;
                    llblShowNewLicensesInfo.Enabled = true;
                    btnIssueReplacement.Enabled = false;

                }
                catch (Exception ex)
                {

                }

            }
        }

        private void rbtnDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement for Damaged License";
            lblTitel.Text = "Replacement for Damaged License";
            lblApplicationFees.Text = clsApplicationTypes.Find(4).Fees.ToString();
        }

        private void rbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement for Lost License";
            lblTitel.Text = "Replacement for Lost License";
            lblApplicationFees.Text = clsApplicationTypes.Find(3).Fees.ToString();
        }
    }
}
