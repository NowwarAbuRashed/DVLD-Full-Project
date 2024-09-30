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
    public partial class frmManageApplicationTypes : Form
    {
        private void _GetAllApplicationTypes()
        {
            dgvApplicationTypes.DataSource =clsApplicationTypes.GetAllApplicationTypes() ;
            lblRecords.Text=dgvApplicationTypes.Rows.Count.ToString() ;
        }
        public frmManageApplicationTypes()
        {
            InitializeComponent();
            _GetAllApplicationTypes();
        }

        private void dgvApplicationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvApplicationTypes.Rows[e.RowIndex].Selected = true;
            }
        }

        private void EditApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvApplicationTypes.SelectedRows[0];
                frmUpdateApplicationType UpdateApplicationType = new frmUpdateApplicationType(Convert.ToInt32(selectedRow.Cells["ApplicationTypeID"].Value));
                UpdateApplicationType.ShowDialog();
                _GetAllApplicationTypes();
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
    }
}
