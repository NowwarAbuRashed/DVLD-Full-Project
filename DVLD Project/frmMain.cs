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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            Form frmPeople = new frmPeople();
            frmPeople.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Form frmUsers=new frmManageUsers();
            frmUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails =new frmUserDetails(clsGlobal.GlobalUser.ID);
            userDetails.ShowDialog();
        }

        private void changPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword =new frmChangePassword(clsGlobal.GlobalUser.ID);
            changePassword.ShowDialog();
        }

        private void btnAccountSettings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                
                cmtAccountSettings.Show(btnAccountSettings, e.Location);
            }
        }

        private void manageApplicatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }

        private void btnApplications_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                cmtApplications.Show(btnApplications, e.Location);
            }
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes listTestTypes = new frmListTestTypes();
            listTestTypes.ShowDialog();
        }

        private void tsmiLocalLicense_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivinglicenseApplication newLocalDrivinglicenseApplication=new frmNewLocalDrivinglicenseApplication();
            newLocalDrivinglicenseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications localDrivingLicenseApplications = new frmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.ShowDialog();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers listDrivers = new frmListDrivers();
            listDrivers.ShowDialog();
        }

        private void tsmiInternationalLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication internationalLicenseApplication = new frmNewInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();

        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplication listInternationalLicenseApplication = new frmListInternationalLicenseApplication();
            listInternationalLicenseApplication.ShowDialog();


        }

        private void tsmiRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense renewLocalDrivingLicense = new frmRenewLocalDrivingLicense();
            renewLocalDrivingLicense.ShowDialog();

        }

        private void tsmiReplacementForLostOrDamagedLicense_Click(object sender, EventArgs e)
        {
            frmReplacementForloseOrDamagedLicense replacementForloseOrDamagedLicense =new frmReplacementForloseOrDamagedLicense();
            replacementForloseOrDamagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses listDetainedLicenses = new frmListDetainedLicenses();
            listDetainedLicenses.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense(-1);
            releaseDetainedLicense.ShowDialog();
        }
    }
}
