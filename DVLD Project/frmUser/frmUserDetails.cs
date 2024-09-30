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
    public partial class frmUserDetails : Form
    {
        clsUsers User;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            User = clsUsers.Find(UserID);
            ctrlPersonInfo1.FillInInfo(clsPepole.Find(User.PersonID));
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = User.UserName;
            if (User.IsActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
