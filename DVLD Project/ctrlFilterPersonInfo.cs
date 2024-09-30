using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlFilterPersonInfo : UserControl
    {
        
        enum enFilterBy
        {
            NationalNo,PersonID
        };
        enFilterBy enFilter;
        DataTable dtPersons;
        clsPepole ConictWithThisPerson;
        private void _GetAllPerson()
        {
            dtPersons = clsPepole.GetAllShortPersonsInfo();
        }
        public ctrlFilterPersonInfo()
        {
            InitializeComponent();
            _GetAllPerson();
        }

        public void ModeUpdate()
        {
            gbFilter.Enabled = false;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enFilterBy.PersonID == (enFilterBy)cmpFilterBy.SelectedIndex)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public void FillInInfo(int PersonID)
        {
            txtFilter.Text = PersonID.ToString();
            cmpFilterBy.SelectedIndex = 1;
            ctrlPersonInfo1.FillInInfo(clsPepole.Find(PersonID));
        }
        private void _GetPersonInfo()
        {
            bool IsFind = false;
            foreach (DataRow Person in dtPersons.Rows) 
            {
                if(enFilter==enFilterBy.PersonID&&Person["PersonID"].ToString()==txtFilter.Text)
                {
                    ConictWithThisPerson = clsPepole.Find(Convert.ToInt32(Person["PersonID"]));
                    ctrlPersonInfo1.FillInInfo(ConictWithThisPerson);
                    IsFind=true;
                }
                else if(enFilter==enFilterBy.NationalNo&& Person["NationalNo"].ToString() == txtFilter.Text)
                {
                    ConictWithThisPerson = clsPepole.Find(Convert.ToInt32(Person["PersonID"]));
                    ctrlPersonInfo1.FillInInfo(ConictWithThisPerson);
                    IsFind=true;
                }
            }
            if(!IsFind)
            {
                MessageBox.Show("The Person Not Exest","Eroee",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnSertch_Click(object sender, EventArgs e)
        {
            _GetPersonInfo();

        }

        private void cmpFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmpFilterBy.SelectedIndex == 0) 
            {
                enFilter=enFilterBy.NationalNo;
            }
            else
            {
                enFilter = enFilterBy.PersonID;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPerson addPerson=new frmAddPerson(-1);
            addPerson.ShowDialog();
            ConictWithThisPerson = clsPepole.Find(addPerson.GetPersonID());
            ctrlPersonInfo1.FillInInfo(ConictWithThisPerson);
            txtFilter.Text= ConictWithThisPerson.ID.ToString();
            cmpFilterBy.SelectedIndex = 1;
        }
        public clsPepole Person()
        {
            return ConictWithThisPerson;
        }
        public int PersonID()
        {
            return ConictWithThisPerson.ID;
        }
        public void DisablefbFilter()
        {
            gbFilter.Enabled = false;
        }
    }
}
