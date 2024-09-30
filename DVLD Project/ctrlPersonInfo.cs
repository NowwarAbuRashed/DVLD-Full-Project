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
    public partial class ctrlPersonInfo : UserControl
    {
        DataTable dtCountry;
        public void FillInInfo(clsPepole Person)
        {
            lblPersonID.Text=Person.ID.ToString();
            lblName.Text=Person.FirstName+" "+Person.SecondName+" "+Person.ThirdName+" "+Person.LastName;
            lblNationalNo.Text=Person.NationalNo;
            if (Person.Gendor == 0)
            {
                lblGendor.Text = "Maile";
                pbGendor.Image = Properties.Resources.user;
                pbPerson.Image = Properties.Resources.person_boy__2_;
            }
            else
            {
                lblGendor.Text = "Female";
                pbGendor.Image = Properties.Resources.user_female;
                pbPerson.Image = Properties.Resources.person_girl__2_;
            }
            lblEmail.Text = Person.Email;
            lblPhone.Text = Person.Phone;
            lblAddress.Text = Person.Address;
            lblDateOfBirth.Text=Person.DateOfBirth.ToString();
            foreach (DataRow dataRow in dtCountry.Rows)
            {
                if (dataRow["CountryID"].ToString() == Person.NationalityCountryID.ToString())
                {
                    lblCountry.Text = dataRow["CountryName"].ToString();
                    break;
                }
            }
            if (Person.ImagePath.ToString() != "" && Person.ImagePath.ToString() != string.Empty)
            {
                pbPerson.Image = Image.FromFile(Person.ImagePath.ToString());
            }
         

        }
        public ctrlPersonInfo()
        {
            InitializeComponent();
            dtCountry=clsCountry.GetAllCountries();
        }

      

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frmAdd=new frmAddPerson(Convert.ToInt32(lblPersonID.Text));
            frmAdd.ShowDialog();
            FillInInfo(clsPepole.Find(Convert.ToInt32(lblPersonID.Text)));

        }
    }
}
