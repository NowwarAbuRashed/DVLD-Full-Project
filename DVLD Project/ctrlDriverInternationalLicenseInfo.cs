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
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public void FillInData(int InternationalLicenseID)
        {
            clsInternationalLicenses internationalLicenses = clsInternationalLicenses.Find(InternationalLicenseID);
            clsApplications applications = clsApplications.Find(internationalLicenses.ApplicationID);
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications;
            DataTable dtLocalDrivingLicens=clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            DataRow drLocalDrivingLicens=null;
            clsPepole person=clsPepole.Find(applications.ApplicationPersonID);
           foreach (DataRow row in dtLocalDrivingLicens.Rows)
            {
                if (Convert.ToInt32(row["ApplicationID"].ToString())== applications.ID)
                {
                    localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()));
                    DataTable dt=clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();
                    foreach (DataRow row2 in dt.Rows)
                    {
                        if (Convert.ToInt32(row2["LocalDrivingLicenseApplicationID"].ToString())== Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString())) 
                        {
                            drLocalDrivingLicens = row2;
                            break;
                        }
                    }
                    break;
                }
            }
            if (drLocalDrivingLicens != null)
            {
                lblName.Text = drLocalDrivingLicens["FullName"].ToString();
                lblIntLicenseID.Text = internationalLicenses.ID.ToString();
                lblLicenseID.Text=internationalLicenses.IssuedUsingLocalLicenseID.ToString();
                lblNationalNo.Text = drLocalDrivingLicens["NationalNo"].ToString();
                if (person.Gendor == 0)
                {
                    lblGendor.Text = "Maile";
                }
                else
                {
                    lblGendor.Text = "Femail";
                }
                lblIssueDate.Text = internationalLicenses.IssueDate.ToString("yyyy/MM/dd");
                lblApplicationID.Text=applications.ID.ToString();
                if (internationalLicenses.IsActive == true)
                {
                    lblIsActive.Text = "Yes";
                }
                else
                {
                    lblIsActive.Text = "No";
                }

                lblDateOfBirth.Text= person.DateOfBirth.ToString("yyyy/MM/dd");

                lblDriverID.Text=internationalLicenses.DriverID.ToString();
                lblExpirationDate.Text = internationalLicenses.ExpirationDate.ToString("yyyy/MM/dd");

                pbPerson.Image = Image.FromFile(person.ImagePath);

            }


        }
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
    }
}
