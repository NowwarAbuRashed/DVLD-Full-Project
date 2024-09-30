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
    public partial class frmDetainLicense : Form
    {
        clsLicenses licenses;
        private void FillInDateToApplicationNew()
        {
            lblDetainDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            lblCreatedBy.Text = clsGlobal.GlobalUser.UserName;
        }
        private void ChickIfCardIsActive(int LicenseID)
        {

            licenses = clsLicenses.Find(LicenseID);
            DataTable dt = clsDetainedLicenses.GetAllDetainedLicenses();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32( row["LicenseID"].ToString())==LicenseID)
                {
                    if (Convert.ToBoolean(row["IsReleased"].ToString())==false) 
                    {
                        MessageBox.Show($"Selected License is already detaiened, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnDetain.Enabled = false;
                        llblShowNewLicensesInfo.Enabled = false;
                        llblShowLicensesHistory.Enabled = true;
                        return;
                    }
                }
            }
            btnDetain.Enabled = true;
            llblShowLicensesHistory.Enabled = true;

            lblLicenseID.Text = LicenseID.ToString();


        }
        private void _ButtonClickedHandler(object sender, EventArgs e)
        {
            if (ctrlFilterDriverLicenseInfo1.GetLicenseID() == 0)
            {
                btnDetain.Enabled = false;
                llblShowNewLicensesInfo.Enabled = false;
                llblShowLicensesHistory.Enabled = false;
                return;
            }
            ChickIfCardIsActive(ctrlFilterDriverLicenseInfo1.GetLicenseID());
        }
        public frmDetainLicense()
        {
            InitializeComponent();
            FillInDateToApplicationNew();
            ctrlFilterDriverLicenseInfo1.ButtonClicked += _ButtonClickedHandler;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the liecese?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();
                    detainedLicenses.LicenseID = licenses.ID;
                    detainedLicenses.DetainDate = DateTime.Now;
                    detainedLicenses.FineFees=Convert.ToDecimal( txtFineFees.Text);
                    detainedLicenses.CreatedByUserID=clsGlobal.GlobalUser.ID;
                    detainedLicenses.IsReleased = false;

                    if (detainedLicenses.Save())
                    {
                        MessageBox.Show($"Licensed Detained Successfully with ID={detainedLicenses.ID}");
                    }
                    lblDetainID.Text =detainedLicenses.ID.ToString();
                        llblShowLicensesHistory.Enabled = true;
                        llblShowNewLicensesInfo.Enabled = true;
                        btnDetain.Enabled = false;
                    

                }
                catch (Exception ex)
                {

                }

            }


        }
    }
}
