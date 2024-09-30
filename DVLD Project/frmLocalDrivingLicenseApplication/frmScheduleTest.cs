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
    public partial class frmScheduleTest : Form
    {
        int ID;
        clsTestAppointments testAppointments;
        enum enModeAddEdit { Edit = 0, Add = 1 };
        enModeAddEdit ModeAddEdit;
        enum enModeTestType { Vision = 1, Written = 2, Practical = 3 };
        enModeTestType ModeTestType;
        private void _FillInData1(int ID, int Trial)
        {
            gbRetakeTestInfo.Enabled = false;
            DataTable dtInfo =clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo(); 

            foreach(DataRow row in dtInfo.Rows)
            {
                if (Convert.ToInt32( row["LocalDrivingLicenseApplicationID"])==ID)
                {
                    lblDLAppID.Text=ID.ToString();
                    lblDClass.Text = row["ClassName"].ToString();
                    lblName.Text = row["FullName"].ToString();
                    lblTrial.Text = Trial.ToString();
                    dtbDate.MinDate=DateTime.Now;
                    lblFees.Text=clsTestTypes.Find(Convert.ToInt32(ModeTestType)).TestTypeFees.ToString();
                    lblTotalFees.Text = lblFees.Text;

                  

                    break;
                }
            }

        }
        private void _FillInData2(int ID, int Trial)
        {
           
            DataTable dtInfo = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();

            foreach (DataRow row in dtInfo.Rows)
            {
                if (Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]) == ID)
                {
                    lblDLAppID.Text = ID.ToString();
                    lblDClass.Text = row["ClassName"].ToString();
                    lblName.Text = row["FullName"].ToString();
                    lblTrial.Text = Trial.ToString();
                    dtbDate.MinDate = DateTime.Now;
                    lblFees.Text = clsTestTypes.Find(Convert.ToInt32(ModeTestType)).TestTypeFees.ToString();
                    if (ModeAddEdit == enModeAddEdit.Add)
                    {
                        gbRetakeTestInfo.Enabled = true;
                        lblRAppFees.Text = "5";
                        
                    }
                    lblTotalFees.Text = (Convert.ToDecimal(lblRAppFees.Text) + Convert.ToDecimal(lblFees.Text)).ToString();

                    break;
                }
            }

        }
        public frmScheduleTest(int ID,int Trial,int Mode,int AppointmentID=-1)
        {
           
            InitializeComponent();


                this.ID = ID;
            if (Mode == 1)
            {
                this.ModeTestType = enModeTestType.Vision;
                pictureBox1.Image = Resources.eye__2_;
            }
            else if (Mode == 2)
            {
                this.ModeTestType = enModeTestType.Written;
                pictureBox1.Image = Resources.exam;
            }
            else
            {
                this.ModeTestType = enModeTestType.Practical;
                pictureBox1.Image = Resources.car__3_;
            }

            if (AppointmentID == -1)
            {
                testAppointments = new clsTestAppointments();
                ModeAddEdit = enModeAddEdit.Add;
                lblRTestAppID.Text = "N/A";
            }
            else
            {
                testAppointments = clsTestAppointments.Find(AppointmentID);
                ModeAddEdit = enModeAddEdit.Edit;
                lblRTestAppID.Text=testAppointments.ID.ToString(); ;
            }
               
                if (Trial == 0)
                {
                    _FillInData1(ID, Trial);
                }
                else
                {
                    _FillInData2(ID, Trial);
                }

            if (testAppointments.IsLocked == true)
            {
                dtbDate.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                dtbDate.Enabled = true;
                btnSave.Enabled = true;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           
            testAppointments.TestTypeID = Convert.ToInt32(ModeTestType);
            testAppointments.LocalDrivingLicenseApplicationID=this.ID;
            testAppointments.AppointmentDate= Convert.ToDateTime(dtbDate.Text);
            testAppointments.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            testAppointments.CreatedByUserID = clsGlobal.GlobalUser.ID;
            testAppointments.IsLocked = false;
            if (testAppointments.Save())
                MessageBox.Show("Data Saved Successfuly.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
