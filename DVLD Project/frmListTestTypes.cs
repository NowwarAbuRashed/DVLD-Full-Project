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
    public partial class frmListTestTypes : Form
    {

        private void _GetAllTestTypes()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lblRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }
        public frmListTestTypes()
        {
            InitializeComponent();

            _GetAllTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTestTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvTestTypes.Rows[e.RowIndex].Selected = true;
            }
        }

        private void EditTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTestTypes.SelectedRows[0];
                frmUpdateTestType updateTestType = new frmUpdateTestType(Convert.ToInt32(selectedRow.Cells["TestTypeID"].Value));
                updateTestType.ShowDialog();
                _GetAllTestTypes();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            
           
        }
    }
}
