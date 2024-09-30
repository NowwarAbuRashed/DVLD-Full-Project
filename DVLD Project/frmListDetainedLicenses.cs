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
    public partial class frmListDetainedLicenses : Form
    {
        enum enFilterBy { None, DetainID, LicenseID, IsReleased, NationalNo, FullName }
        enFilterBy enFilter;
        private void _GetAllDetainedLicenses()
        {
            dgvShowAllDetainedLicenses.DataSource = clsDetainedLicenses.GetAllDetainedLicensesInfo();
            lblRecords.Text = dgvShowAllDetainedLicenses.Rows.Count.ToString();
        }


        public frmListDetainedLicenses()
        {
            InitializeComponent();
            _GetAllDetainedLicenses();
        }

   
        private void Filter(string filterColumn, string text)
        {

            DataTable dataTable = clsDetainedLicenses.GetAllDetainedLicensesInfo();
            if (text == "")
            {
                dgvShowAllDetainedLicenses.DataSource = dataTable;
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


            dgvShowAllDetainedLicenses.DataSource = filteredTable;
        }

   
    

        private void dgvShowAllDetainedLicenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllDetainedLicenses.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
            _GetAllDetainedLicenses();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense(-1);
            releaseDetainedLicense.ShowDialog();
            _GetAllDetainedLicenses();
        }

        private void cmpFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmpFilterBy.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
                txtFilter.Text = "";
                Filter("None", "");
            }
            enFilter = (enFilterBy)cmpFilterBy.SelectedIndex;
            if (enFilter == enFilterBy.IsReleased)
            {
                txtFilter.Visible = false;
                cbFilterActive.Visible = true;
            }
            else
            {
                cbFilterActive.Visible = false;
            }
        }

        private void cbFilterActive_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (cbFilterActive.SelectedIndex == 2)
                Filter("IsReleased", "false");
            else
                Filter("IsReleased", "true");

            lblRecords.Text = dgvShowAllDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            switch (enFilter)
            {
                case enFilterBy.None:
                    break;
                case enFilterBy.DetainID:
                    Filter("DetainID", txtFilter.Text);
                    break;
                case enFilterBy.LicenseID:
                    Filter("LicenseID", txtFilter.Text);
                    break;
                case enFilterBy.IsReleased:
                    Filter("IsReleased", txtFilter.Text);
                    break;
                case enFilterBy.NationalNo:
                    Filter("NationalNo", txtFilter.Text);
                    break;
                case enFilterBy.FullName:
                    Filter("FullName", txtFilter.Text);
                    break;
            }
            lblRecords.Text = dgvShowAllDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllDetainedLicenses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllDetainedLicenses.SelectedRows[0];
                int PersonID = clsApplications.Find(clsLicenses.Find((Convert.ToInt32(selectedRow.Cells["LicenseID"].Value))).ApplicationID).ApplicationPersonID;
                frmPersonDetails personDetails = new frmPersonDetails(PersonID);
                personDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
           
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllDetainedLicenses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllDetainedLicenses.SelectedRows[0];
                frmLicenseInfo licenseInfo = new frmLicenseInfo((Convert.ToInt32(selectedRow.Cells["LicenseID"].Value)));
                licenseInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllDetainedLicenses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllDetainedLicenses.SelectedRows[0];
                frmReleaseDetainedLicense releaseDetainedLicense = new frmReleaseDetainedLicense((Convert.ToInt32(selectedRow.Cells["LicenseID"].Value)));
                releaseDetainedLicense.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllDetainedLicenses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllDetainedLicenses.SelectedRows[0];

                int ApplicatioID = clsApplications.Find(clsLicenses.Find((Convert.ToInt32(selectedRow.Cells["LicenseID"].Value))).ApplicationID).ID;
                DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["ApplicationID"].ToString()) == ApplicatioID)
                    {
                        frmLicenseHistory licenseHistory = new frmLicenseHistory(Convert.ToInt32(row["LocalDrivingLicenseApplicationID"].ToString()));
                        licenseHistory.ShowDialog();
                        break;
                    }

                }

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }

        }
    }
}
