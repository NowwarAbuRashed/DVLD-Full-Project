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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project
{
    public partial class frmListInternationalLicenseApplication : Form
    {

        enum enFilterBy { None = 0, IntLicenseID, ApplicationID, DriverID, LLicesnseID, IssueDate, ExpirationDate, IsActive};
        enFilterBy enFilter;
        private void FillInDateToDGV()
        {
            DataTable dt = clsInternationalLicenses.GetAllInternationalLicenses();
            dgvShowAllInternationalLicenseApplications.DataSource = dt;
            lblRecords.Text = dgvShowAllInternationalLicenseApplications.Rows.Count.ToString();

        }
        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
            FillInDateToDGV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShowAllInternationalLicenseApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllInternationalLicenseApplications.Rows[e.RowIndex].Selected = true;
            }
        }

        private void Filter(string filterColumn, string text)
        {

            DataTable dataTable =clsInternationalLicenses.GetAllInternationalLicenses();
            if (text == "")
            {
                dgvShowAllInternationalLicenseApplications.DataSource = dataTable;
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
            else if (columnType == typeof(bool))
            {
                if (bool.TryParse(text, out bool boolValue))
                {
                    filterExpression = $"{filterColumn} = {boolValue}";
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


            dgvShowAllInternationalLicenseApplications.DataSource = filteredTable;
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
                Filter("None", "");
            }
            enFilter = (enFilterBy)cmpFilterBy.SelectedIndex;
            if (enFilter == enFilterBy.IsActive)
            {
                txtFiler.Visible = false;
                cbFilterActive.Visible = true;
            }
            else
            {
                cbFilterActive.Visible = false;
            }
        }

        private void txtFiler_TextChanged(object sender, EventArgs e)
        {
            switch (enFilter)
            {


                case enFilterBy.IntLicenseID:
                    Filter("InternationalLicenseID", txtFiler.Text);

                    break;
                case enFilterBy.ApplicationID:
                    Filter("ApplicationID", txtFiler.Text);
                    break;
                case enFilterBy.DriverID:
                    Filter("DriverID", txtFiler.Text);
                    break;
                case enFilterBy.LLicesnseID:
                    Filter("IssuedUsingLocalLicenseID", txtFiler.Text);
                    break;

                default:
                    Filter("NationalNo", "");
                    break;
            }
            lblRecords.Text = dgvShowAllInternationalLicenseApplications.Rows.Count.ToString();

        }

        private void txtFiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enFilterBy.IntLicenseID == (enFilterBy)cmpFilterBy.SelectedIndex || enFilterBy.ApplicationID == (enFilterBy)cmpFilterBy.SelectedIndex
                || enFilterBy.DriverID == (enFilterBy)cmpFilterBy.SelectedIndex || enFilterBy.LLicesnseID == (enFilterBy)cmpFilterBy.SelectedIndex)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilterActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterActive.SelectedIndex == 2)
                Filter("IsActive", "false");
            else
                Filter("IsActive", "true");

            lblRecords.Text = dgvShowAllInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllInternationalLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllInternationalLicenseApplications.SelectedRows[0];
                frmPersonDetails frmshowPersonDetails = new frmPersonDetails(clsApplications.Find( Convert.ToInt32(selectedRow.Cells["ApplicationID"].Value)).ApplicationPersonID);
                frmshowPersonDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }


        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllInternationalLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllInternationalLicenseApplications.SelectedRows[0];
                frmInternationalDriverInfo internationalDriverInfo = new frmInternationalDriverInfo(Convert.ToInt32(selectedRow.Cells["InternationalLicenseID"].Value));
                internationalDriverInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllInternationalLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllInternationalLicenseApplications.SelectedRows[0];

                DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
                foreach(DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(selectedRow.Cells["ApplicationID"].Value) == Convert.ToInt32(row["ApplicationID"].ToString()))
                    {
                        frmLicenseHistory frmshowPersonDetails = new frmLicenseHistory(Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()));
                        frmshowPersonDetails.ShowDialog();
                        break;
                    }
                }
               
               
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void btnAddInterationalLicenseApplications_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication newInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
            newInternationalLicenseApplication.ShowDialog();
            FillInDateToDGV();

        }
    }
}
