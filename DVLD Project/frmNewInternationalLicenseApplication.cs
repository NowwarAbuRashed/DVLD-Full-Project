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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private void _FillInData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblIssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblFees.Text=clsApplicationTypes.Find(6).Fees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");
            lblCreatedBy.Text=clsGlobal.GlobalUser.UserName.ToString(); 

        }
        private void _FillInDataApplicationInfo()
        {
            if(ctrlFilterDriverLicenseInfo1.GetLicenseID()==0)
            {
                return;
            }
            DataTable dt = clsInternationalLicenses.GetAllInternationalLicenses();
            foreach (DataRow row in dt.Rows)
            {
                if (clsApplications.Find(Convert.ToInt32(row["ApplicationID"].ToString())).ApplicationPersonID
                    == clsApplications.Find(clsLicenses.Find(Convert.ToInt32(ctrlFilterDriverLicenseInfo1.GetLicenseID())).ApplicationID).ApplicationPersonID &&
                    Convert.ToBoolean(row["IsActive"].ToString()) == true &&
                   clsLicenses.Find(Convert.ToInt32(ctrlFilterDriverLicenseInfo1.GetLicenseID())).LicenseClass == 3)
                {

                    MessageBox.Show($"Person already have an active international license with ID = {clsInternationalLicenses.Find(Convert.ToInt32(row["InternationalLicenseID"].ToString())).ID}", "Not Exest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


            }
            lblLocalLicenseID.Text = ctrlFilterDriverLicenseInfo1.GetLicenseID().ToString();
            btnIssue.Enabled = true;
            llblShowLicensesHistory.Enabled = true;

        }
        private void _ButtonClickedHandler(object sender, EventArgs e)
        {
            _FillInDataApplicationInfo(); // استدعاء الدالة بدون معلمات
        }
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            _FillInData();
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
            foreach(DataRow row in dt.Rows)
            {
                if (ApplicationID == Convert.ToInt32( row["ApplicationID"].ToString()))
                {
                    frmLicenseHistory licenseHistory = new frmLicenseHistory(Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()));
                    licenseHistory.ShowDialog();
                    break;
                }


            }

           
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            clsLicenses licenses = clsLicenses.Find(ctrlFilterDriverLicenseInfo1.GetLicenseID());
            DataTable table =clsInternationalLicenses.GetAllInternationalLicenses();

            foreach(DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ApplicationID"].ToString()) == licenses.ApplicationID)
                {

                    MessageBox.Show($"Person already have zn active international license with ID ={Convert.ToInt32(row["InternationalLicenseID"].ToString())}");
                    return;
                }

            }
            if (MessageBox.Show("Are you suer you want to issue the license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                clsInternationalLicenses internationalLicenses = new clsInternationalLicenses();
                internationalLicenses.ApplicationID = licenses.ApplicationID;
                internationalLicenses.DriverID = licenses.DriverID;
                internationalLicenses.IssuedUsingLocalLicenseID = ctrlFilterDriverLicenseInfo1.GetLicenseID();
                internationalLicenses.IssueDate = Convert.ToDateTime(lblIssueDate.Text);
                internationalLicenses.ExpirationDate = internationalLicenses.IssueDate.AddYears(1);
                internationalLicenses.IsActive = true;
                internationalLicenses.CreatedByUserID = clsGlobal.GlobalUser.ID;

                if (internationalLicenses.Save())
                {
                    MessageBox.Show($"International License Issued Successfully with ID={internationalLicenses.ID}", "License Issued");
                    llblShowLicensesInfo.Enabled = true;
                    lblILLicenseID.Text = internationalLicenses.ID.ToString();
                    lblILApplicationID.Text=internationalLicenses.ApplicationID.ToString();
                }
            }
        }

        private void llblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo internationalDriverInfo = new frmInternationalDriverInfo(Convert.ToInt32(lblILLicenseID.Text));
            internationalDriverInfo.ShowDialog();

        }
    }
}
