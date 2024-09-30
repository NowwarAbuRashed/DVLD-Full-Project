using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmLogIn : Form
    {

        private string  _filePathRememberUserNameAndPassword = "D:\\19 - Full Real Project\\RememberUserNameAndPassword.txt";

        public frmLogIn()
        {
            InitializeComponent();
            RetreveDataRemember();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Remember()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;  // Store passwords securely in a real application

            // Write username and password to a file
            using (StreamWriter writer = new StreamWriter(_filePathRememberUserNameAndPassword))
            {
                writer.WriteLine(userName);
                writer.WriteLine(password);
            }

        }
        void NotRemember()
        {
            File.WriteAllText(_filePathRememberUserNameAndPassword, string.Empty);
        }
        void RetreveDataRemember()
        {


            if (File.Exists(_filePathRememberUserNameAndPassword))
            {
                // Read the username and password from the file
                string[] lines = File.ReadAllLines(_filePathRememberUserNameAndPassword);
                if (lines.Length > 0)
                {
                    string userName = lines[0];
                    string password = lines[1];

                    txtUserName.Text = userName;
                    txtPassword.Text = password;
                }
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {


            DataTable InfoUsers =clsUsers.GetAllUsers();
            bool isFound = false;
            foreach (DataRow Row in InfoUsers.Rows)
            {
                if (txtUserName.Text == Row["UserName"].ToString() && txtPassword.Text== Row["Password"].ToString())
                {
                    isFound = true;
                    if (Convert.ToBoolean( Row["IsActive"])==true)
                    {
                        if(cbRememberMe.Checked==true)
                        {
                            Remember();
                        }
                        else
                        {
                            NotRemember();
                        }
                       clsGlobal.GlobalUser = clsUsers.Find(Convert.ToInt32(Row["UserID"]));
                        frmMain main = new frmMain();
                        main.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("the User Not Active", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (!isFound)
            {
                MessageBox.Show("Invalid Username/Password", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
