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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int DrivingLisenseApplicationID)
        {
            InitializeComponent();
            ctrlDriverLicenseInfo1.FillInDate(DrivingLisenseApplicationID);
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
