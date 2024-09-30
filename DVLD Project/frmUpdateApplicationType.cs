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
    public partial class frmUpdateApplicationType : Form
    {
        clsApplicationTypes ApplicationTypes;

        private void FillInDate()
        {
            lblApplicationTypeID.Text =ApplicationTypes.ID.ToString();
            txtTitel.Text = ApplicationTypes.Title;
            txtFees.Text = ApplicationTypes.Fees.ToString();
                
        }
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            ApplicationTypes = clsApplicationTypes.Find(ApplicationTypeID); 
            FillInDate();
        }


        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplicationTypes.Title = txtTitel.Text;
            ApplicationTypes.Fees = Convert.ToDecimal(txtFees.Text);
            if(ApplicationTypes.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved");
            }
            else
            {
                MessageBox.Show("Filed","Faild",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
