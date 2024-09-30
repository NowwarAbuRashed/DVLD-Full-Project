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
    public partial class ctrlFilterDriverLicenseInfo : UserControl
    {

        public event EventHandler ButtonClicked;
        public ctrlFilterDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int GetLicenseID()
        {
            if (int.TryParse(txtFilter.Text, out int number))
            {  
                return number;
            }
            return 0;
        }
        public void SetLicenseID(int number)
        {
            txtFilter.Text = number.ToString();
        }
        public void FilterEnabelFalse()
        {
            gbFilter.Enabled = false;
        }
        private void btnSertch_Click(object sender, EventArgs e)
        {
            if(clsLicenses.Find(Convert.ToInt32(txtFilter.Text)) == null )
            {
                MessageBox.Show("The License Not Found","Not Exest",MessageBoxButtons.OK,MessageBoxIcon.Error);
               return;
            }
            if(clsLicenses.Find(Convert.ToInt32(txtFilter.Text)).LicenseClass != 3)
            {
                MessageBox.Show("The License Not Found", "Not Exest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            


            ctrlDriverLicenseInfo1.FillInDate(Convert.ToInt32(txtFilter.Text));
            if (ButtonClicked != null)
            {
                ButtonClicked(this, EventArgs.Empty); // إطلاق الحدث
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
