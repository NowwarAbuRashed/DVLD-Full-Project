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
    public partial class frmChangePassword : Form
    {
        clsUsers User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            User=clsUsers.Find(UserID);
            ctrlPersonInfo1.FillInInfo(clsPepole.Find(User.PersonID));
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = User.UserName;
            if(User.IsActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text != User.Password.ToString())
            {
                errorProvider1.SetError(txtCurrentPassword, "current password is wrong!");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, string.Empty);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Password can not be Blank!");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, string.Empty);
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password does not math Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsControlValid(Control control)
        {
            string errorMessage = errorProvider1.GetError(control);
            return string.IsNullOrEmpty(errorMessage);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsControlValid(txtConfirmPassword) && IsControlValid(txtNewPassword) && IsControlValid(txtCurrentPassword))
            {
                User.Password = txtNewPassword.Text;
                if (User.Save())
                {
                    MessageBox.Show("Password Changed Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Handel the Erorr", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
