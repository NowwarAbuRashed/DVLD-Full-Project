using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsApplications
    {
        public int ID {  get; set; }
        public int ApplicationPersonID {  get; set; }
        
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID {  get; set; }
        public int ApplicationStatus { get; set; }

        public DateTime lastStatusDate { get; set; }
        public decimal PaidFees {  get; set; }

        public int CreatedByUserID {  get; set; }

        enum enMode { Add,Update};
        enMode Mode;
        public clsApplications()
        {
           this. ID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.lastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode=enMode.Add;
        }

        private clsApplications(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus,
             DateTime lastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            Mode=enMode.Update;
        }

        static public clsApplications Find(int ID)
        {

            int ApplicationPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            int ApplicationStatus = 0;
            DateTime lastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            if (clsApplicationsDataAccess.Find(ID, ref ApplicationPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
             ref lastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplications(ID,  ApplicationPersonID,  ApplicationDate, ApplicationTypeID, ApplicationStatus,
             lastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }


        private bool _AddAplication()
        {
            this.ID= clsApplicationsDataAccess.AddApplication(this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.lastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ID != -1) ;
        }

        private bool _UpdateAplication()
        {
            return clsApplicationsDataAccess.UpdateApplication(this.ID, this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.lastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode) 
            {
                case enMode.Add:
                    return _AddAplication();
                    break;
                case enMode.Update:
                    return _UpdateAplication();
                    break;
            }
            return false;
        }

        static public DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

    }
}
