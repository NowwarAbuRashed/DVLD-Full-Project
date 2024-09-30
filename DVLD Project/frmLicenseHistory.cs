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
    public partial class frmLicenseHistory : Form
    {
        int PersonID;
        int LocalDrivingLicenseApplicationID;
        private void _FillInDate()
        {
            ctrlFilterPersonInfo1.FillInInfo(PersonID);
            ctrlFilterPersonInfo1.DisablefbFilter();


        }
        private void _FillInDateToDGVLocal(int ApplicationID)
        {
            DataTable dt = clsLicenses.GetAllShortLicensessInfo();
            DataTable filteredTable =dt.Clone();


            foreach(DataRow row in dt.Rows )
            {

                if (clsApplications.Find(Convert.ToInt32( row["ApplicationID"].ToString())).ApplicationPersonID== clsApplications.Find(ApplicationID).ApplicationPersonID)
                {
                    filteredTable.ImportRow(row);
                }

            }

            dgvLocalLicensesHistory.DataSource = filteredTable;
            
            lblRecordsLocal.Text=dgvLocalLicensesHistory.Rows.Count.ToString();


        }
        private void _FillInDateToDGVInternational(int ApplicationID)
        {
            DataTable dt = clsInternationalLicenses.GetAllInternationalLicenses();
            DataTable filteredTable = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {

                if(clsApplications.Find(Convert.ToInt32(row["ApplicationID"].ToString())).ApplicationPersonID == clsApplications.Find(ApplicationID).ApplicationPersonID)
                {
                    filteredTable.ImportRow(row);
                }

            }
            dgvInternationalLicensesHistory.DataSource= filteredTable;
            lblRecordsInternational.Text= dgvInternationalLicensesHistory.Rows.Count.ToString() ;

        }

            public frmLicenseHistory(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(LocalDrivingLicenseApplicationID);
            PersonID = clsApplications.Find(localDrivingLicenseApplications.ApplicationID).ApplicationPersonID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _FillInDateToDGVLocal(localDrivingLicenseApplications.ApplicationID);
            _FillInDateToDGVInternational(localDrivingLicenseApplications.ApplicationID);
            _FillInDate();

        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicensesHistory.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvLocalLicensesHistory.SelectedRows[0];
                frmLicenseInfo licenseInfo = new frmLicenseInfo(Convert.ToInt32(selectedRow.Cells["LicenseID"].Value));
                licenseInfo.ShowDialog(this);

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
