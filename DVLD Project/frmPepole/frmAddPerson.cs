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
    public partial class frmAddPerson : Form
    {
       
        public frmAddPerson(int PersonID)
        {
            InitializeComponent();
            if(PersonID ==-1)
            {
                lblTitile.Text = "Add New Person";
                lblPersonID.Text = "N/A";
                PersonID = ctrlAddEditPerson1.PersonID();


                ctrlAddEditPerson1.DataBack += ChangeToUpdate;



            }
            if(PersonID != -1)
            {
                lblTitile.Text = "Update Person";
                ctrlAddEditPerson1.ChickPerson(PersonID);
                lblPersonID.Text= ctrlAddEditPerson1.PersonID().ToString();
            }

        }
        private void ChangeToUpdate()
        {    
            lblTitile.Text = "Update Person";
            lblPersonID.Text = ctrlAddEditPerson1.PersonID().ToString();
        }
        public int GetPersonID()
        {
            return Convert.ToInt32(lblPersonID.Text);
        }

        private void frmAddPerson_Load(object sender, EventArgs e)
        {

        }
    }
}
