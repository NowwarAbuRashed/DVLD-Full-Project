using DVLD_Project.frmLocalDrivingLicenseApplication;
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
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        enum enFilterBy { None = 0, LocalDrivingLicenseApplicationID, NationalNo, FullName, Statusl };
        enFilterBy enFilter;
        private void _GetAllLocalDrivingLicenseApplication()
        {
            dgvShowAllLocalDrivingLicenseApplications.DataSource =clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();
            lblRecords.Text = dgvShowAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _GetAllLocalDrivingLicenseApplication();
        }

        private void dgvShowAllLocalDrivingLicenseApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllLocalDrivingLicenseApplications.Rows[e.RowIndex].Selected = true;


            }
        }
        private void Filter(string filterColumn, string text)
        {

            DataTable dataTable = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();
            if (text == "")
            {
                dgvShowAllLocalDrivingLicenseApplications.DataSource = dataTable;
                return;
            }
            // Get the column data type
            Type columnType = dataTable.Columns[filterColumn].DataType;

            // Build the filter expression
            string filterExpression;
            if (columnType == typeof(string))
            {
                filterExpression = $"{filterColumn} LIKE '%{text}%'";
            }
            else if (columnType == typeof(int))
            {
                if (int.TryParse(text, out int numericValue))
                {
                    filterExpression = $"{filterColumn} = {numericValue}";
                }
                else
                {
                    filterExpression = $"{filterColumn} IS NULL"; // Handle case when text is not a valid number
                }
            }
            else
            {
                // Handle other data types as necessary
                filterExpression = $"{filterColumn} IS NULL"; // Default case
            }

            // Apply filter to the DataTable
            DataRow[] filteredRows = dataTable.Select(filterExpression);

            // Create a new DataTable to hold the filtered results
            DataTable filteredTable = dataTable.Clone(); // Clones the structure (schema) of the original table
            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            // Update the DataGridView or other UI elements with the filtered data


            dgvShowAllLocalDrivingLicenseApplications.DataSource = filteredTable;

        }
       private void cmpFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmpFilterBy.SelectedIndex != 0)
            {
                txtFiler.Visible = true;
            }
            else
            {
                txtFiler.Visible = false;
                txtFiler.Text = "";
                Filter("NationalNo", "");
            }
            enFilter = (enFilterBy)cmpFilterBy.SelectedIndex;
        }
        private void txtFiler_TextChanged(object sender, EventArgs e)
        {
            switch (enFilter)
            {


                case enFilterBy.None:
                    Filter("None", txtFiler.Text);

                    break;
                case enFilterBy.LocalDrivingLicenseApplicationID:
                    Filter("LocalDrivingLicenseApplicationID", txtFiler.Text);
                    break;
                case enFilterBy.NationalNo:
                    Filter("NationalNo", txtFiler.Text);
                    break;
                case enFilterBy.FullName:
                    Filter("FullName", txtFiler.Text);
                    break;
                case enFilterBy.Statusl:
                    Filter("Status", txtFiler.Text);
                    break;
              
            }
            lblRecords.Text = dgvShowAllLocalDrivingLicenseApplications.Rows.Count.ToString();

        }

        private void txtFiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enFilterBy.LocalDrivingLicenseApplicationID == (enFilterBy)cmpFilterBy.SelectedIndex)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivinglicenseApplication newLocalDrivinglicenseApplication =new frmNewLocalDrivinglicenseApplication();
            newLocalDrivinglicenseApplication.ShowDialog();
        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                    clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value));
                    clsApplications applications = clsApplications.Find(LocalDrivingLicenseApplication.ApplicationID);
                    applications.ApplicationStatus = 2;
                    if (applications.Save())
                    {
                        MessageBox.Show("Data Saved Successfuly.", "Saved");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }

            _GetAllLocalDrivingLicenseApplication();

        }

        private void cmsEditLocalDrivingLicenseApplications_Opening(object sender, CancelEventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {
                

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                if(selectedRow.Cells["Status"].Value.ToString()!="New")
                {
                    EditApplicationtoolStripMenuItem2.Enabled = false;
                    DeleteApplicationToolStripMenuItem.Enabled = false;
                    CancelApplicationToolStripMenuItem.Enabled = false;
                    SechduleTestsToolStripMenuItem.Enabled = false;
                }
                else
                {
                    EditApplicationtoolStripMenuItem2.Enabled = true;
                    DeleteApplicationToolStripMenuItem.Enabled = true;
                    CancelApplicationToolStripMenuItem.Enabled = true;
                    SechduleTestsToolStripMenuItem.Enabled = true;
                }

                if (Convert.ToInt32(selectedRow.Cells["PassedTestCount"].Value) == 0)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else if (Convert.ToInt32(selectedRow.Cells["PassedTestCount"].Value) == 1)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                }
                else if (Convert.ToInt32(selectedRow.Cells["PassedTestCount"].Value) == 2)
                {
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                }
                else
                {

                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;

                }

                if(selectedRow.Cells["Status"].Value.ToString() != "New" && Convert.ToInt32(selectedRow.Cells["PassedTestCount"].Value) == 3)
                {
                    SechduleTestsToolStripMenuItem.Enabled = false;
                    IssueDrivingLicenseToolStripMenuItem.Enabled = false;
                }
                else if(selectedRow.Cells["Status"].Value.ToString() == "New" && Convert.ToInt32(selectedRow.Cells["PassedTestCount"].Value) == 3)
                {
                    SechduleTestsToolStripMenuItem.Enabled = false;
                    IssueDrivingLicenseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    IssueDrivingLicenseToolStripMenuItem.Enabled = false;
                }
                if(selectedRow.Cells["Status"].Value.ToString() == "Completed")
                {
                    showLicenseToolStripMenuItem1.Enabled = true;
                }
                else
                {
                    showLicenseToolStripMenuItem1.Enabled=false;
                }

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }


        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {
                
                    DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                                frmTestAppointments visionTestAppointments =new frmTestAppointments(
Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value),1);
                visionTestAppointments.ShowDialog();
                   
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            _GetAllLocalDrivingLicenseApplication();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                frmTestAppointments writtenTestAppointments = new frmTestAppointments(
Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value),2);
                writtenTestAppointments.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            _GetAllLocalDrivingLicenseApplication();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                frmTestAppointments writtenTestAppointments = new frmTestAppointments(
Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value), 3);
                writtenTestAppointments.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            _GetAllLocalDrivingLicenseApplication();
        }

        private void IssueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                frmIssueDrivingLicenseForTheFirstTime issueDrivingLicenseForTheFirstTime = new frmIssueDrivingLicenseForTheFirstTime(
                    Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value));

                issueDrivingLicenseForTheFirstTime.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            _GetAllLocalDrivingLicenseApplication();
        }

        private void showLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                frmLicenseInfo licenseInfo =
                    new frmLicenseInfo(Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value));

                licenseInfo.ShowDialog(this);

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvShowAllLocalDrivingLicenseApplications.SelectedRows[0];
                frmLicenseHistory licenseHistory =
                    new frmLicenseHistory(Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value));

                licenseHistory.ShowDialog(this);

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }

        }
    }
}
