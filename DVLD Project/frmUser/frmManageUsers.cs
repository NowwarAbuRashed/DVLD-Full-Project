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
    public partial class frmManageUsers : Form
    {
        enum enFilterBy {None,UserID,UserName,personID,FullName,IsActive }
        enFilterBy enFilter;
        private void _GetAllUsers()
        {
            dgvShowAllUsers.DataSource = clsUsers.GetAllShortUserInfo();
            lblRecords.Text = dgvShowAllUsers.Rows.Count.ToString();
        }
        public frmManageUsers()
        {
            InitializeComponent();
            _GetAllUsers();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser(-1);
            addUser.ShowDialog();
            _GetAllUsers();
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
                Filter("UserName", "");
            }
            enFilter = (enFilterBy)cmpFilterBy.SelectedIndex;
            if(enFilter==enFilterBy.IsActive)
            {
                txtFilter.Visible = false;
                cbFilterActive.Visible = true;
            }
            else
            {
                cbFilterActive.Visible = false;
            }
        }
        private void Filter(string filterColumn, string text)
        {

            DataTable dataTable =clsUsers.GetAllShortUserInfo();
            if (text == "")
            {
                dgvShowAllUsers.DataSource = dataTable;
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


            dgvShowAllUsers.DataSource = filteredTable;           
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (enFilter)
            {
                case enFilterBy.None:
                    break;
                    case enFilterBy.UserID:
                    Filter("UserID", txtFilter.Text);
                    break;
                    case enFilterBy.UserName:
                    Filter("UserName", txtFilter.Text);
                    break;
                    case enFilterBy.personID:
                    Filter("personID", txtFilter.Text);
                    break;
                    case enFilterBy.FullName:
                    Filter("FullName", txtFilter.Text);
                    break;
            }
            lblRecords.Text = dgvShowAllUsers.Rows.Count.ToString();

        }

        private void cbFilterActive_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (cbFilterActive.SelectedIndex == 2)
                    Filter("IsActive", "false");
                else
                    Filter("IsActive", "true");

            lblRecords.Text = dgvShowAllUsers.Rows.Count.ToString();
        }

        private void dgvShowAllUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllUsers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void EditStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dgvShowAllUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllUsers.SelectedRows[0];
                Form frmAddUser = new frmAddUser(Convert.ToInt32(selectedRow.Cells["UserID"].Value));
                frmAddUser.ShowDialog();
                _GetAllUsers();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllUsers.SelectedRows[0];
                if (clsUsers.DeleteUser(Convert.ToInt32(selectedRow.Cells["UserID"].Value)))
                    {
                    MessageBox.Show("Deleted Succssfulle", "Succssfulle");
                    _GetAllUsers();
                }
                else
                {
                    MessageBox.Show("User is not deleted due to dta connected to it", "Filde",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser(-1);
            addUser.ShowDialog();
            _GetAllUsers();
        }

        private void changePasswordStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvShowAllUsers.SelectedRows.Count > 0)
            {
                    DataGridViewRow selectedRow = dgvShowAllUsers.SelectedRows[0];
                    frmChangePassword changePassword = new frmChangePassword(Convert.ToInt32(selectedRow.Cells["UserID"].Value));
                    changePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllUsers.SelectedRows[0];
                frmUserDetails userDetails = new frmUserDetails(Convert.ToInt32(selectedRow.Cells["UserID"].Value));
                userDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
           

        }
    }
}
