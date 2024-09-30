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

namespace DVLD_Project.frmLocalDrivingLicenseApplication
{
    public partial class frmIssueDrivingLicenseForTheFirstTime : Form
    {
        int DrivingLicenseApplicationID;
        public frmIssueDrivingLicenseForTheFirstTime(int DrivingLicenseApplicationID)
        {
            InitializeComponent();
            ctrlDrivingLicenseApplicationInfo1._FillInInfo(DrivingLicenseApplicationID);
            this.DrivingLicenseApplicationID = DrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications=clsLocalDrivingLicenseApplications.Find(this.DrivingLicenseApplicationID);
            clsApplications applications = clsApplications.Find(localDrivingLicenseApplications.ApplicationID);
            applications.ApplicationStatus = 3;
            applications.Save();

            clsDrivers drivers=new clsDrivers();
            drivers.PersonID = applications.ApplicationPersonID;
            drivers.CreatedByUserID=clsGlobal.GlobalUser.ID;
            drivers.CreatedDate = DateTime.Now;
            drivers.Save();

            clsLicenses licenses=new clsLicenses();
            licenses.ApplicationID = localDrivingLicenseApplications.ApplicationID;
            licenses.DriverID = drivers.ID;
            licenses.LicenseClass = localDrivingLicenseApplications.LicenseClassID;
            licenses.IssueDate = DateTime.Now;
            licenses.ExpirationDate= licenses.IssueDate.AddYears(clsLicenseClasses.Find(localDrivingLicenseApplications.LicenseClassID).DefaultValidityLength);
            licenses.Notes=txtNotes.Text;
            licenses.PaidFees = 0;
            licenses.IsActive = true;
            licenses.IssueReason = 0;
            licenses.CreatedByUserID = clsGlobal.GlobalUser.ID;
            if(licenses.Save())
            {
                MessageBox.Show($"License Issued Successfuly with License ID ={licenses.ID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
