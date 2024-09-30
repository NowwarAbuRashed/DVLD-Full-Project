using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDetainedLicenses
    {
        public int ID { get; set; }
        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }

        public decimal FineFees {  get; set; }

        public int CreatedByUserID {  get; set; }

        public bool IsReleased { get; set; }

        public DateTime? ReleaseDate {  get; set; }

        public int? ReleasedByUserID { get; set; }

        public int? ReleaseApplicationID {  get; set; }

        enum enMode { Add, Update };
        enMode Mode;
        public clsDetainedLicenses()
        {
            this.ID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now; 
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate=null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID =null;
                Mode=enMode.Add;
        }

        public clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            this.ID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            Mode=enMode.Update;
        }



        static public clsDetainedLicenses Find(int DetainID)
        {

            int LicenseID = -1;
            DateTime DetainDate =DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;

            if (DetainedLicensesDataAccess.Find(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,ref IsReleased,ref ReleaseDate,ref ReleasedByUserID,ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }


        private bool _AddDetainedLicenses()
        {
            this.ID = DetainedLicensesDataAccess.AddDetainedLicenses(this.LicenseID, this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);

            return (this.ID != -1);

        }
        private bool _UpdateDetainedLicenses()
        {
            return DetainedLicensesDataAccess.UpdateDetainedLicenses(this.ID,this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    return _AddDetainedLicenses();
                    break;
                case enMode.Update:
                    return _UpdateDetainedLicenses();
                    break;
                default:
                    return false;
            }

        }

        static public DataTable GetAllDetainedLicenses()
        {
            return DetainedLicensesDataAccess.GetAllDetainedLicenses();
        }
        static public DataTable GetAllDetainedLicensesInfo()
        {
            return DetainedLicensesDataAccess.GetAllDetainedLicensesInfo();
        }


    }
}
