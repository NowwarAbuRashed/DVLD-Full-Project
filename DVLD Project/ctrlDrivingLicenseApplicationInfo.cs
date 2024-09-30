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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        int PassedTest;
        public void _FillInInfo(int DrivingLicenseApplicationID)
        {
            DataTable LocalDrivingLicense=clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();

            foreach(DataRow row in LocalDrivingLicense.Rows)
            {
                if (Convert.ToInt32(row["LocalDrivingLicenseApplicationID"])==DrivingLicenseApplicationID)
                {
                    
                    lblDLAppID.Text = DrivingLicenseApplicationID.ToString();
                    lblAppliedForLicense.Text = row["ClassName"].ToString();
                    PassedTest =Convert.ToInt32( row["PassedTestCount"]);
                    lblPassedTests.Text = row["PassedTestCount"].ToString() + "/3";


                    clsApplications applications = clsApplications.Find(clsLocalDrivingLicenseApplications.Find(DrivingLicenseApplicationID).ApplicationID);

                    lblID.Text = applications.ID.ToString();
                    lblStatus.Text = row["Status"].ToString();
                    lblFees.Text=applications.PaidFees.ToString();

                    clsApplicationTypes applicationTypes = clsApplicationTypes.Find(applications.ApplicationTypeID);

                    lblType.Text=applicationTypes.Title.ToString();
                    lblApplicant.Text = row["FullName"].ToString();
                    lblDate.Text = applications.ApplicationDate.ToString();
                    lblStatusDate.Text = applications.lastStatusDate.ToString();

                    lblCreatedBy.Text=clsGlobal.GlobalUser.UserName;


                    break;
                }


            }


        }
        public int GetDrivingLicenseApplicationID()
        {
            return Convert.ToInt32(lblDLAppID.Text);
        }
        public int GetPassedTestCount()
        {
            
            return Convert.ToInt32(PassedTest);
        }
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmPersonDetails personDetails = new frmPersonDetails(clsPepole.Find(clsApplications.Find(Convert.ToInt32(lblID.Text)).ApplicationPersonID).ID);
            personDetails.ShowDialog();
        }
    }
}
