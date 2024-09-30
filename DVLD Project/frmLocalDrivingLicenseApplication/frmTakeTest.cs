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

    public partial class frmTakeTest : Form
    {
        enum enMode { Vision=1,Written=2,Practical=3};
        enMode Mode;
        int TestAppointmentID;
        int Trial;
        clsTestAppointments testAppointments;
        private void _FillInData1()
        {


            DataTable dtInfo = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();

             testAppointments = clsTestAppointments.Find(TestAppointmentID);
            foreach (DataRow row in dtInfo.Rows)
            {
                if (Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]) == testAppointments.LocalDrivingLicenseApplicationID)
                {
                    lblDLAppID.Text = testAppointments.LocalDrivingLicenseApplicationID.ToString();
                    lblDClass.Text = row["ClassName"].ToString();
                    lblName.Text = row["FullName"].ToString();
                    lblTrial.Text = Trial.ToString();
                    lblDate.Text= testAppointments.AppointmentDate.ToString();
                    lblFees.Text = clsTestTypes.Find(Convert.ToInt32(Mode)).TestTypeFees.ToString();



                    break;
                }
            }



        }
        public frmTakeTest(int TestAppointmentID,int Trial,int Mode)
        {

            InitializeComponent();
            if(Mode==1)
            {
                this.Mode = enMode.Vision;
                pictureBox1.Image = Resources.eye__2_;
            }
            else if(Mode==2)
            {
                this.Mode = enMode.Written;
                pictureBox1.Image = Resources.exam;
            }
            else
            {
                this.Mode = enMode.Practical;
                pictureBox1.Image = Resources.car__3_;
            }
            this.TestAppointmentID = TestAppointmentID;
            this.Trial = Trial;
            _FillInData1();
            rbtnPass.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes) {
                clsTests tests = new clsTests();
                tests.TestAppointmentID = TestAppointmentID;
                if (rbtnPass.Checked)
                {
                    tests.TestResult = true;
                }
                else
                {
                    tests.TestResult = false;
                }
                tests.Notes = txtNotes.Text;
                tests.CreatedByUserID = clsGlobal.GlobalUser.ID;
                testAppointments.IsLocked = true;
                testAppointments.Save();
                if (tests.Save())
                {
                    MessageBox.Show("Data Saved Successfuly.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
