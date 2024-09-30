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
    public partial class frmReleaseDetainedLicense : Form
    {
        int LicenseID=-1;
        clsLicenses licenses;
        clsDetainedLicenses detainedLicenses;

    
        private void ChickIfCardDetained(int LicenseID)
        {
            licenses = clsLicenses.Find(LicenseID);
            DataTable dt = clsDetainedLicenses.GetAllDetainedLicenses();
            bool flage = false;
            foreach(DataRow row in dt.Rows)
            {
                if (Convert.ToInt32( row["LicenseID"].ToString())==licenses.ID)
                {
                    if (Convert.ToBoolean(row["IsReleased"].ToString())==true)
                    {
                       flage = true;
                    }
                    else
                    {
                        flage= false;
                        detainedLicenses = clsDetainedLicenses.Find(Convert.ToInt32(row["DetainID"].ToString()));
                        break;
                    }
                   
                }
            }
            if (flage) 
            {
                MessageBox.Show($" {licenses.ExpirationDate}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = true;
                lblLicenseID.Text = LicenseID.ToString();
                return; 
            }

            btnRelease.Enabled = true;
            llblShowLicensesHistory.Enabled = true;
            lblDetainDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            lblLicenseID.Text = LicenseID.ToString();
            lblApplicationFees.Text = clsApplicationTypes.Find(5).Fees.ToString();
            lblFineFees.Text = detainedLicenses.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text)).ToString();
            lblCreatedBy.Text=detainedLicenses.CreatedByUserID.ToString();


        }
        private void _ButtonClickedHandler(object sender, EventArgs e)
        {
            if (ctrlFilterDriverLicenseInfo1.GetLicenseID() == 0)
            {
                btnRelease.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                return;
            }
            if (this.LicenseID != -1)
            {
                ChickIfCardDetained(this.LicenseID);
                ctrlFilterDriverLicenseInfo1.FilterEnabelFalse();

            }
            else
            {
                ChickIfCardDetained(ctrlFilterDriverLicenseInfo1.GetLicenseID());
            }
        }
        public frmReleaseDetainedLicense(int LicenseID)

        {
            InitializeComponent();
            if (LicenseID != -1)
            {
                this.LicenseID = LicenseID;
                ctrlFilterDriverLicenseInfo1.SetLicenseID(LicenseID);
            }
        
            ctrlFilterDriverLicenseInfo1.ButtonClicked += _ButtonClickedHandler;
        }

       
        private void llblShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(licenses.ID);
            licenseInfo.ShowDialog();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    clsApplications applicationsNew = new clsApplications();

                    applicationsNew.ApplicationPersonID = clsApplications.Find(licenses.ApplicationID).ApplicationPersonID;
                    applicationsNew.ApplicationDate = DateTime.Now;
                    applicationsNew.ApplicationTypeID = clsApplicationTypes.Find(5).ID;
                    applicationsNew.ApplicationStatus = 3;
                    applicationsNew.lastStatusDate = DateTime.Now;
                    applicationsNew.PaidFees = clsApplicationTypes.Find(applicationsNew.ApplicationTypeID).Fees;
                    applicationsNew.CreatedByUserID = clsGlobal.GlobalUser.ID;

                    applicationsNew.Save();


                    detainedLicenses.IsReleased=true;
                    detainedLicenses.ReleaseDate = DateTime.Now;
                    detainedLicenses.ReleasedByUserID = clsGlobal.GlobalUser.ID;
                    detainedLicenses.ReleaseApplicationID = applicationsNew.ID;
                    if (detainedLicenses.Save())
                    {
                        MessageBox.Show($"Detained License Released Successfully", "Detained License Released");
                        lblApplicationID.Text = applicationsNew.ID.ToString();
                    }
                    llblShowLicensesHistory.Enabled = true;
                    llblShowNewLicensesInfo.Enabled = true;
                    btnRelease.Enabled = false;

                }
                catch (Exception ex)
                {

                }

            }
        }
    }
}
