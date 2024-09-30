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
    public partial class frmNewLocalDrivinglicenseApplication : Form
    {
        enum enApplicationType { NewLocalDrivingLicenseService=1 }
        enum enTestType { VisionTest=1 }
        enum enApplicationStatus { New=1 , Completed=2,Cancelled=3}
        

        int PersonID = -1;
        DataTable dtLicenseClass;
        clsApplicationTypes applicationTypes = clsApplicationTypes.Find((int)enApplicationType.NewLocalDrivingLicenseService);
        clsApplications Applications=new clsApplications();
        clsLocalDrivingLicenseApplications localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
        DataTable dtApplicatios;
        DataTable dtLocalDrivingLicenseApplications;



        private void _FillInCountry()
        {
            dtLicenseClass = clsLicenseClasses.GetAllLicenseClasses();
            cmbLicenseClass.Items.Clear();
            foreach (DataRow dataRow in dtLicenseClass.Rows)
            {
                cmbLicenseClass.Items.Add(dataRow["ClassName"].ToString());
            }
        }
        private void _FillInApplicationInfoInFrom()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = applicationTypes.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.GlobalUser.UserName;

        }
       
        public frmNewLocalDrivinglicenseApplication()
        {
            InitializeComponent();
            _FillInCountry();
            cmbLicenseClass.SelectedIndex = 2;
            _FillInApplicationInfoInFrom();
            dtApplicatios=clsApplications.GetAllApplications();
            dtLocalDrivingLicenseApplications=clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        }
       
        private void btnNext_Click(object sender, EventArgs e)
        {
            
                if (ctrlFilterPersonInfo1.Person()==null)
                {
                    MessageBox.Show("Select Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
            tabControl1.SelectedIndex += 1;
            PersonID = ctrlFilterPersonInfo1.PersonID();
        }

        private void _FillInApplicationInfoIn()
        {
            Applications.ApplicationPersonID = PersonID;
            Applications.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            Applications.ApplicationTypeID = applicationTypes.ID;
            Applications.ApplicationStatus = clsTestTypes.Find((int)enTestType.VisionTest).ID;
            Applications.lastStatusDate = DateTime.Now;
            Applications.PaidFees = applicationTypes.Fees;
            Applications.CreatedByUserID = clsGlobal.GlobalUser.ID;
        }
        private bool _ChaickIfApplicationStatusIsExestAndNew(ref int ApplicationTypeIDisExest)
        {
            bool IsExestAndNew = false;
            foreach(DataRow row in dtApplicatios.Rows)
            {
                
                if (
                    Convert.ToInt32(row["ApplicationPersonID"])== Applications.ApplicationPersonID &&
                    Convert.ToInt32(row["ApplicationTypeID"]) == Applications.ApplicationTypeID &&
                    Convert.ToInt32(row["ApplicationStatus"])==(int)enApplicationStatus.New
                   )
                {
                    IsExestAndNew = true;
                    ApplicationTypeIDisExest = Convert.ToInt32(row["ApplicationID"]);
                    break;
                }

            }

            return IsExestAndNew;
        }
        private bool _ChickIfTheSameClass()
        {
            bool IsSame=false;
            foreach(DataRow row in dtLocalDrivingLicenseApplications.Rows)
            {
                if (
                    Convert.ToInt32(row["LicenseClassID"]) == cmbLicenseClass.SelectedIndex + 1
                    ) 
                {

                    IsSame = true;
                    break;
                }

            }
            return IsSame;
        }
        private void _FillInlocalDrivingLicenseApplications()
        {
            localDrivingLicenseApplications.ApplicationID = Applications.ID;
            localDrivingLicenseApplications.LicenseClassID=cmbLicenseClass.SelectedIndex+1;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillInApplicationInfoIn();
            int ApplicationTypeIDisExest = -1;
            if (_ChaickIfApplicationStatusIsExestAndNew(ref ApplicationTypeIDisExest))
            {
                if(_ChickIfTheSameClass())
                {
                  MessageBox.Show($"Choose another License Class, the selected Person Already have an active application for the selected calss with id={ApplicationTypeIDisExest}", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
              {
                    if (Applications.Save()) 
                {
                        _FillInlocalDrivingLicenseApplications();
                        if (localDrivingLicenseApplications.Save()) 
                        {
                            MessageBox.Show("Data Saved Successfuly.", "Saved");
                            lblDLApplcationID.Text = Applications.ID.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Faild.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                else
                {
                    MessageBox.Show("Faild.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              }
            }
            else
            {
                if (Applications.Save())
                {
                    _FillInlocalDrivingLicenseApplications();
                    if (localDrivingLicenseApplications.Save())
                    {
                        MessageBox.Show("Data Saved Successfuly.", "Saved");
                        lblDLApplcationID.Text = Applications.ID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Faild.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            dtApplicatios = clsApplications.GetAllApplications();
            dtLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
