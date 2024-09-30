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
    public partial class frmPeople : Form
    {
        enum enFilterBy { None=0 , PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Nattionality, Gendor, Phone, Email };
        enFilterBy enFilter;
        private void _GetAllPerson()
        {
            dgvShowAllPersons.DataSource= clsPepole.GetAllShortPersonsInfo();


            
        }
        public frmPeople()
        {
            InitializeComponent();
            _GetAllPerson();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddPerson(-1);
            frmAddPerson.ShowDialog();

            

            _GetAllPerson();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            if (dgvShowAllPersons.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllPersons.SelectedRows[0];
                Form frmAddPerson = new frmAddPerson(Convert.ToInt32(selectedRow.Cells["PersonID"].Value));
                frmAddPerson.ShowDialog();
                _GetAllPerson();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllPersons.SelectedRows.Count > 0)
            {
       
                DataGridViewRow selectedRow = dgvShowAllPersons.SelectedRows[0];
                int PersonID = Convert.ToInt32(selectedRow.Cells["PersonID"].Value);
                if (MessageBox.Show($"Are you sure you want to delete Person [{PersonID}]","Confirm Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK) 
                {
                    clsPepole Person = clsPepole.Find(PersonID);
                    string ImagePath = Person.ImagePath.ToString();
                    if (!clsPepole.DeletePerson(PersonID)) 
                    {
                        MessageBox.Show("person was not deleted because it has data linked to it.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ctrlAddEditPerson.DeleteImage(ImagePath);
                    }
                }
                _GetAllPerson();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void dgvShowAllPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvShowAllPersons.Rows[e.RowIndex].Selected = true;
            }
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

        private void Filter(string filterColumn, string text)
        {
         
            DataTable dataTable = clsPepole.GetAllShortPersonsInfo();
            if (text == "")
            {
                dgvShowAllPersons.DataSource = dataTable;
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
           
          
                dgvShowAllPersons.DataSource = filteredTable; 
            
        }

        private void txtFiler_TextChanged(object sender, EventArgs e)
        {
            switch (enFilter) {

           
            case enFilterBy.PersonID:
                    Filter("PersonID", txtFiler.Text);
                    
                break;
            case enFilterBy.NationalNo:
                    Filter("NationalNo", txtFiler.Text);
                    break;
            case enFilterBy.FirstName:
                    Filter("FirstName", txtFiler.Text);
                    break;
            case enFilterBy.SecondName:
                    Filter("SecondName", txtFiler.Text);
                    break;
            case enFilterBy.ThirdName:
                    Filter("ThirdName", txtFiler.Text);
                    break;
            case enFilterBy.LastName:
                    Filter("LastName", txtFiler.Text);
                    break;
            case enFilterBy.Nattionality:
                    Filter("Nationalty", txtFiler.Text);
                    break;
            case enFilterBy.Gendor:
                    Filter("Gendor", txtFiler.Text);
                    break;
            case enFilterBy.Phone:
                    Filter("Phone", txtFiler.Text);
                    break;
            case enFilterBy.Email:
                    Filter("Email", txtFiler.Text);
                    break;
            default:
                    Filter("NationalNo", "");
                    break;
            }
        }

        private void txtFiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enFilterBy.PersonID==(enFilterBy)cmpFilterBy.SelectedIndex || enFilterBy.Phone == (enFilterBy)cmpFilterBy.SelectedIndex) 
            { 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowAllPersons.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvShowAllPersons.SelectedRows[0];
                frmPersonDetails PersonDetails = new frmPersonDetails(Convert.ToInt32(selectedRow.Cells["PersonID"].Value));
                PersonDetails.ShowDialog();
                _GetAllPerson();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
           
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddPerson(-1);
            frmAddPerson.ShowDialog();



            _GetAllPerson();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featuer is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This featuer is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
