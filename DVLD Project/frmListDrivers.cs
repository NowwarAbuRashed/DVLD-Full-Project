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
    public partial class frmListDrivers : Form
    {
        enum enFilterBy { None, DriverID, personID,NationalNo, FullName}
        enFilterBy enFilter;
        private void _GetAllDrivers()
        {
            dgvShowAllDrivers.DataSource = clsDrivers.GetAllDriversInfo();

            lblRecords.Text = dgvShowAllDrivers.Rows.Count.ToString();
        }
        public frmListDrivers()
        {
            InitializeComponent(); 
            _GetAllDrivers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmpFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmpFilterBy.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
                txtFilter.Text = "";
                Filter("FullName", "");
            }
            enFilter = (enFilterBy)cmpFilterBy.SelectedIndex;
        
        }

        private void Filter(string filterColumn, string text)
        {

            DataTable dataTable = clsDrivers.GetAllDriversInfo();
            if (text == "")
            {
                dgvShowAllDrivers.DataSource = dataTable;
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


            dgvShowAllDrivers.DataSource = filteredTable;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (enFilter)
            {
                case enFilterBy.None:
                    break;
                case enFilterBy.DriverID:
                    Filter("DriverID", txtFilter.Text);
                    break;
                case enFilterBy.personID:
                    Filter("personID", txtFilter.Text);
                    break;
              
                case enFilterBy.NationalNo:
                    Filter("NationalNo", txtFilter.Text);
                    break;
                case enFilterBy.FullName:
                    Filter("FullName", txtFilter.Text);
                    break;
            }
            lblRecords.Text = dgvShowAllDrivers.Rows.Count.ToString();
        }

        private void dgvShowAllDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllDrivers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enFilterBy.personID == (enFilterBy)cmpFilterBy.SelectedIndex || enFilterBy.DriverID == (enFilterBy)cmpFilterBy.SelectedIndex)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
