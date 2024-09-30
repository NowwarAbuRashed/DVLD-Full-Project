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
    public partial class frmUpdateTestType : Form
    {
        clsTestTypes testTypes;
        private void _FillInData()
        {
            lblTestTypeID.Text =testTypes.ID.ToString();
            txtTitel.Text = testTypes.TestTypeTitle;
            txtDescription.Text = testTypes.TestTypeDescription;
            txtFees.Text=testTypes.TestTypeFees.ToString();

        }
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            testTypes=clsTestTypes.Find(TestTypeID);
            _FillInData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            testTypes.TestTypeTitle = txtTitel.Text;
            testTypes.TestTypeDescription = txtDescription.Text;
            testTypes.TestTypeFees = Convert.ToDecimal(txtFees.Text);

            if (testTypes.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved");
            }
            else
            {
                MessageBox.Show("Filed", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
