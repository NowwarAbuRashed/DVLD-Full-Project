using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Project
{
    public partial class ctrlAddEditPerson : UserControl
    {

        public delegate void DataBackEventHandler();

        public event DataBackEventHandler DataBack;

        DataTable PersonsInfo;
        clsPepole Person= new clsPepole();
        private string ImagePath=string.Empty;
        DataTable dtCountry;
        enum enGendor { Male=0,Female=1};
        public ctrlAddEditPerson()
        {
            InitializeComponent();
            PersonsInfo=clsPepole.GetAllPersons();
            dtDateOfBirth.MaxDate = (DateTime.Now.Date.AddYears(-18));
            rbtnMail.Checked = true;
            _FillInCountry();
        }
        public void ChickPerson(int PersonId)
        {
            Person = clsPepole.Find(PersonId);
            if(Person.ImagePath!=""&&Person.ImagePath!=null)
            llblDelete.Visible = true;
            if (Person == null)
            {
                Person = new clsPepole();
                llblDelete.Visible=false;
                return;
            }
            _FillinBoxInfo();
        }

        private void _FillinBoxInfo()
        {
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtEmail.Text = Person.Email;
            txtPhone.Text = Person.Phone;
            txtNationalNo.Text = Person.NationalNo;

            if (Person.Gendor == 0)
            {
                rbtnMail.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }

           
            foreach (DataRow dataRow in dtCountry.Rows)
            {
                if (dataRow["CountryID"].ToString() == Person.NationalityCountryID.ToString())
                {
                    combCountry.Text = dataRow["CountryName"].ToString();
                    break;
                }
            }

            txtAddress.Text = Person.Address;
            if (Person.ImagePath.ToString() != ""&& Person.ImagePath.ToString()!=string.Empty)
            {
                pbPerson.Image = Image.FromFile(Person.ImagePath.ToString());
                ImagePath = Person.ImagePath.ToString();
            }
        }
       
        public int PersonID()
        {
            return Person.ID;
        }
    
        private void _FillInCountry()
        {
             dtCountry=clsCountry.GetAllCountries();
            combCountry.Items.Clear();
            foreach(DataRow dataRow in dtCountry.Rows)
            {
                combCountry.Items.Add(dataRow["CountryName"].ToString());
            }
        }
        private void _FillInPersonInfo(ref clsPepole Person)
        {

            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.NationalNo = txtNationalNo.Text;
            Person.Email = txtEmail.Text;
            Person.Address = txtAddress.Text;
            Person.Phone = txtPhone.Text;
            if(ImagePath==""|| ImagePath==string.Empty)
            {
                Person.ImagePath = string.Empty;
            }
            {
                Person.ImagePath = ImagePath;
            }
            DataTable contry = clsCountry.GetAllCountries();

            foreach (DataRow row in contry.Rows)
            {
                if (row["CountryName"].ToString() == combCountry.Text)
                {
                    Person.NationalityCountryID = Convert.ToInt32(row["CountryID"].ToString());
                    break;
                }
            }


            if (rbtnMail.Checked)
                Person.Gendor =  Convert.ToByte(enGendor.Male);
            else
                Person.Gendor = Convert.ToByte(enGendor.Female);


            Person.DateOfBirth = dtDateOfBirth.Value;

            Person.Save();
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ImagePath != string.Empty)
            { CopyImageFile(ImagePath); }
            _FillInPersonInfo(ref Person);
            MessageBox.Show("Data Saved Successfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChickPerson(Person.ID);

            DataBack?.Invoke();

           
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {

            if (PersonID() == -1)
            {
                foreach (DataRow row in PersonsInfo.Rows)
                {
                    if (row["NationalNo"].ToString() == txtNationalNo.Text)
                    {
                        errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
                        return;
                    }
                }
                errorProvider1.SetError(txtNationalNo, string.Empty);
            }
        }

        private void rbtnMail_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.person_boy__2_;
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.person_girl__2_;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            if(!txtEmail.Text.EndsWith("@gmail.com") || txtEmail.Text.Length<=10)
            {
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }
        }

       

        private string SelectImageFile()
        {
            if (ImagePath!= "" &&ImagePath!= string.Empty)
            {
                _DeleteImageFile(ImagePath);
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\"; // Set the initial directory
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Show the OpenFileDialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file's path
                    string selectedFilePath = openFileDialog.FileName;

                   
                    pbPerson.Image=Image.FromFile(selectedFilePath);
                    return selectedFilePath;
                }
            }
            return "";
        }
        private void CopyImageFile(string SelectImageFile)
        {
            // Specify the source and destination paths
            string sourceFilePath = SelectImageFile; // Replace with your source file path
            string destinationDirectory = @"D:\DVLD Pictsher"; // Replace with your destination file path
            string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceFilePath));
            try
            {
                // Check if the source file exists
                if (File.Exists(sourceFilePath))
                {
                    // Copy the file to the destination
                    File.Copy(sourceFilePath, destinationFilePath, true); // 'true' allows overwriting if the file exists
                    ImagePath = sourceFilePath;
                   
                }
            }
            catch (IOException ex)
            {
            }
           
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImagePath = SelectImageFile();
            llblDelete.Visible = true;
        }


        private void _DeleteImageFile(string SelectImageFile)
        {
            // Specify the source and destination paths
            
                // Access the file here

                string sourceFilePath = SelectImageFile; // Replace with your source file path
                string destinationDirectory = @"D:\DVLD Pictsher"; // Replace with your destination file path
                string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceFilePath));

                try
                {
                    // Check if the file already exists in the destination and delete it
                    if (File.Exists(destinationFilePath))
                    {
                        File.Delete(destinationFilePath);
                    }
                }
                catch (IOException ex)
                {
                    // Handle the exception (optional)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            
        }
        static public void DeleteImage(string SelectImageFile)
        {
            string sourceFilePath = SelectImageFile; // Replace with your source file path
            string destinationDirectory = @"D:\DVLD Pictsher"; // Replace with your destination file path
            string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceFilePath));

            try
            {
                // Check if the file already exists in the destination and delete it
                if (File.Exists(destinationFilePath))
                {
                    File.Delete(destinationFilePath);
                }
            }
            catch (IOException ex)
            {
                // Handle the exception (optional)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private void llblDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you shore to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _DeleteImageFile(ImagePath);
                     ImagePath = string.Empty;
                pbPerson.Image = Properties.Resources.person_boy__2_;
                llblDelete.Visible = false;
            }
        }

        private void combCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            // Check if the form is found, then close it
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
