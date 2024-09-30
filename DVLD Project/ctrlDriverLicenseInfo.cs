using DVLD_Project.Properties;
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
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        public void FillInDate(int DrivingLicenseID)
        {
            bool flage=false;
            int ID;
            if (clsLicenses.Find(DrivingLicenseID) != null) 
            { 
                DataTable dt1 =clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
                 ID = clsLicenses.Find(DrivingLicenseID).ApplicationID;
                foreach (DataRow row1 in dt1.Rows)
                {
                    if (ID == Convert.ToInt32(row1["ApplicationID"].ToString()))
                    {
                        ID = Convert.ToInt32(row1["LocalDrivingLicenseApplicationID"].ToString());
                        flage = true;
                        break;
                    }
                }
            }
            else
            {
                ID =  DrivingLicenseID;
                flage = true;
            }
           

          

            if (flage)
            {
                clsLocalDrivingLicenseApplications localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(ID);
                DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()) == localDrivingLicenseApplications.ID)
                    {
                        pbPerson.Image = Image.FromFile(clsPepole.Find(clsApplications.Find(localDrivingLicenseApplications.ApplicationID).ApplicationPersonID).ImagePath);
                        lblDateOfBirth.Text = Convert.ToDateTime(clsPepole.Find(clsApplications.Find(localDrivingLicenseApplications.ApplicationID).ApplicationPersonID).DateOfBirth).ToString("yyyy/MM/dd");
                        lblClass.Text = row["ClassName"].ToString();
                        lblName.Text = row["FullName"].ToString();

                        if (Convert.ToInt32(clsPepole.Find(clsApplications.Find(localDrivingLicenseApplications.ApplicationID).ApplicationPersonID).Gendor) == 0)
                        {
                            lblGendor.Text = "Maile";
                            pbGendor.Image = Resources.person_boy__2_;
                        }
                        else
                        {
                            lblGendor.Text = "Femail";
                            pbGendor.Image = Resources.person_girl__2_;
                        }
                        lblNationalID.Text = row["NationalNo"].ToString();

                        clsApplications applications = clsApplications.Find(localDrivingLicenseApplications.ApplicationID);

                        DataTable dt2 = clsLicenses.GetAllLicensess();
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            if (Convert.ToInt32(row2["ApplicationID"].ToString()) == localDrivingLicenseApplications.ApplicationID &&
                                Convert.ToInt32(row2["LicenseClass"].ToString()) == localDrivingLicenseApplications.LicenseClassID )
                            {
                                lblLicenseID.Text = row2["LicenseID"].ToString();

                                lblIssueDate.Text = Convert.ToDateTime(row2["IssueDate"].ToString()).ToString("yyyy/MM/dd");
                                lblExpirationDate.Text = Convert.ToDateTime(row2["ExpirationDate"].ToString()).ToString("yyyy/MM/dd");

                                if (Convert.ToBoolean(row2["IsActive"].ToString()) == true)
                                    lblIsActive.Text = "Yes";
                                else
                                    lblIsActive.Text = "No";

                                lblDriverID.Text = row2["DriverID"].ToString();

                                DataTable dt3 = clsDetainedLicenses.GetAllDetainedLicenses();
                                bool flage2 = false;
                                foreach (DataRow row3 in dt3.Rows)
                                {
                                    if (Convert.ToInt32(row3["LicenseID"].ToString()) == Convert.ToInt32(row2["LicenseID"].ToString()))
                                    {
                                        if (Convert.ToBoolean(row3["IsReleased"].ToString()) == false)
                                        {
                                           flage2 = true;
                                        }
                                        else
                                        {
                                            flage2=false;
                                        }
                                    }
                                }
                                if (flage2)
                                {
                                    lblIsDetained.Text = "Yes";
                                }
                                else
                                {
                                     lblIsDetained.Text = "No";   
                                }

                                if (Convert.ToInt32(row2["IssueReason"].ToString()) == 2)
                                { 
                                     lblIssueReason.Text = "Renew";
                                }
                                else if(Convert.ToInt32(row2["IssueReason"].ToString()) == 3)
                                {
                                    lblIssueReason.Text = "Replacement for lost";
                                }
                                else if (Convert.ToInt32(row2["IssueReason"].ToString()) == 4)
                                {
                                    lblIssueReason.Text = "Replacement for Damage";
                                }
                                else
                                {
                                    lblIssueReason.Text = "First Time";
                                }

                                    lblNotes.Text = row2["Notes"].ToString();
                                if (row2["Notes"].ToString() == string.Empty)
                                {
                                    lblNotes.Text = "No Notes";
                                }

                                break;
                            }
                        }






                        break;
                    }
                }

            }

        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void lblDClass_Click(object sender, EventArgs e)
        {

        }
    }
}
