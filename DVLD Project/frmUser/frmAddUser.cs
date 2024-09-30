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
    public partial class frmAddUser : Form
    {
        DataTable dtUsers;
        int PersonID=-1;
        clsUsers AddUser=null;
        public frmAddUser(int UserID)
        {
            InitializeComponent();
            dtUsers=clsUsers.GetAllUsers();
            ChickUser(UserID);
        }

        private void _FillInInfo()
        {
            ctrlFilterPersonInfo1.FillInInfo(AddUser.PersonID);
            lblUserID.Text=AddUser.ID.ToString();
            txtUserName.Text=AddUser.UserName;
            txtPassword.Text=AddUser.Password;
            txtConfirmPassword.Text = AddUser.Password;
        }
        public void ChickUser(int UserID)
        {
            clsUsers FoundUser = clsUsers.Find(UserID);
            if (FoundUser != null)
            {
                AddUser = FoundUser;
                lblTitel.Text = "Update User";
                ctrlFilterPersonInfo1.ModeUpdate();
                btnNext.Enabled = false;
                _FillInInfo();
            }
            else
            {
                AddUser = new clsUsers();
                btnNext.Enabled = true;
                lblTitel.Text = "Add New User";
            }


        }

        private void txtNext_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row["PersonID"].ToString() == ctrlFilterPersonInfo1.PersonID().ToString())
                {
                    MessageBox.Show("Select Person already has a user, choose another one.", "Select another Person",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            tabControl1.SelectedIndex += 1;
            PersonID =ctrlFilterPersonInfo1.PersonID();

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row["UserName"].ToString() == txtUserName.Text && AddUser.ID==-1)
                {
                    errorProvider1.SetError(txtUserName, "UserName can not be Blank!");
                    return;
                }
            }
            errorProvider1.SetError(txtUserName, string.Empty);

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password can not be Blank!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text!=txtPassword.Text)
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            AddUser.PersonID = PersonID;
            AddUser.UserName = txtUserName.Text;
            AddUser.Password = txtPassword.Text;
            if(cbIsActive.Checked==true)
            {
                AddUser.IsActive = true;
            }
            else
            {
                AddUser.IsActive=false;
            }
          if(  AddUser.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved");
            }
            lblUserID.Text = AddUser.ID.ToString();
            ChickUser(AddUser.ID);

        }
    }
}
