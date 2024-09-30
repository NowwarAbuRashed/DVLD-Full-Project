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
    public partial class frmTestAppointments : Form
    {
        DataTable filteredTable;
        enum enModeTestType { Vision = 1, Written = 2, Practical = 3 };
        enModeTestType ModeTestType;

        private void _FillInDateInDGV(int DrinvingLincesAplicationID, int TestTypeID)
        {
            DataTable dt = clsTestAppointments.GetAllTestAppointments();
             filteredTable=dt.Clone();
           

            foreach (DataRow row in dt.Rows)
            {
                int ID = Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]);
                int TestypeId = Convert.ToInt32(row["TestTypeID"]);
                if(ID== DrinvingLincesAplicationID && TestypeId== TestTypeID)
                {
                    filteredTable.ImportRow(row);
                }

            }

            dgvAppointments.DataSource = filteredTable;
            dgvAppointments.Columns["TestTypeID"].Visible = false;
            dgvAppointments.Columns["LocalDrivingLicenseApplicationID"].Visible = false;
            dgvAppointments.Columns["CreatedByUserID"].Visible = false;

            lblRecords.Text = dgvAppointments.Rows.Count.ToString();

        }

        public frmTestAppointments(int DrinvingLincesAplicationID,int ModeTestType)
        {
            InitializeComponent();
            if(ModeTestType==1)
            {
                this.ModeTestType = enModeTestType.Vision;
                pictureBox1.Image = Resources.eye__2_;
                this.Text = "Vision Test Appointments";
                lblTitelform.Text = "Vision Test Appointments";
            }
            else if(ModeTestType==2)
            {

                this.ModeTestType = enModeTestType.Written;
                pictureBox1.Image = Resources.exam;
                this.Text = "Written Test Appointments";
                lblTitelform.Text= "Written Test Appointments";
            }
            else if(ModeTestType==3) 
            {

                this.ModeTestType = enModeTestType.Practical;
                pictureBox1.Image = Resources.car__3_;
                this.Text = "Practical Test Appointments";
                lblTitelform.Text = "Practical Test Appointments";
            }

            ctrlDrivingLicenseApplicationInfo1._FillInInfo(DrinvingLincesAplicationID);
            _FillInDateInDGV(DrinvingLincesAplicationID,Convert.ToInt32(this.ModeTestType));
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if((ctrlDrivingLicenseApplicationInfo1.GetPassedTestCount()!=0 && ModeTestType==enModeTestType.Vision) ||
                (ctrlDrivingLicenseApplicationInfo1.GetPassedTestCount() != 1 && ModeTestType == enModeTestType.Written) ||
                 (ctrlDrivingLicenseApplicationInfo1.GetPassedTestCount() != 2 && ModeTestType == enModeTestType.Practical)

                )
            {
                MessageBox.Show("this Person Already passed this test before,you cane only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataRow row in filteredTable.Rows)
            {
                if(Convert.ToBoolean( row["IsLocked"])==false)
                {
                    MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }


            }
            frmScheduleTest scheduleTest = new frmScheduleTest(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID(), dgvAppointments.Rows.Count, Convert.ToInt32(this.ModeTestType));
            scheduleTest.ShowDialog();
            ctrlDrivingLicenseApplicationInfo1._FillInInfo(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID());
            _FillInDateInDGV(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID(), Convert.ToInt32(this.ModeTestType));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];

                frmScheduleTest scheduleTest = new frmScheduleTest(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID(),
                    dgvAppointments.Rows.Count,
                    2,Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value));

                scheduleTest.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            ctrlDrivingLicenseApplicationInfo1._FillInInfo(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID());
            _FillInDateInDGV(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID(), Convert.ToInt32(this.ModeTestType));
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvAppointments.Rows[e.RowIndex].Selected = true;
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];

                frmTakeTest TakeTest = new frmTakeTest(Convert.ToInt32(selectedRow.Cells["TestAppointmentID"].Value), dgvAppointments.Rows.Count, Convert.ToInt32(this.ModeTestType));

                TakeTest.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            ctrlDrivingLicenseApplicationInfo1._FillInInfo(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID());
            _FillInDateInDGV(ctrlDrivingLicenseApplicationInfo1.GetDrivingLicenseApplicationID(), Convert.ToInt32(this.ModeTestType));
        }
    }
}
