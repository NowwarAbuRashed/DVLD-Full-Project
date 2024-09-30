using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBusinessLayer
{
    public class clsLicenses
    {
        public int ID {  get; set; }

        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }

        public int LicenseClass {  get; set; }

        public DateTime IssueDate {  get; set; }

        public DateTime ExpirationDate {  get; set; }

        public string Notes {  get; set; }

        public decimal PaidFees {  get; set; }

        public bool IsActive {  get; set; }

        public int IssueReason {  get; set; }

        public int CreatedByUserID { get; set; }

        enum enMode { Add, Update };
        enMode Mode;
        public clsLicenses()
        {
            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;
            DriverID = -1;
            LicenseClass = 0;
            IssueDate = DateTime.Now;
            LicenseClass = 0;
            Mode = enMode.Add;
        }

        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.ID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees= PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }



        static public clsLicenses Find(int LicenseID)
        {


          
            int ApplicationID = -1;
            int DriverID=-1;
            int LicenseClass = 0;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = true;
            int IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicensesDataAccess.Find(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes,ref PaidFees , ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        private bool _AddLicenses()
        {
            this.ID = clsLicensesDataAccess.AddLicenses(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,this.ExpirationDate,
                this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);

            return (this.ID != -1);

        }
        private bool _UpdateLicenses()
        {
            return clsLicensesDataAccess.UpdateLicenses(this.ID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    return _AddLicenses();
                    break;
                case enMode.Update:
                    return _UpdateLicenses();
                    break;
                default:
                    return false;
            }

            

        }

        static public DataTable GetAllLicensess()
        {
            return clsLicensesDataAccess.GetAllLicenses();
        }


        static public DataTable GetAllShortLicensessInfo()
        {
            return clsLicensesDataAccess.GetAllShortLicensessInfo();
        }



    }
}
