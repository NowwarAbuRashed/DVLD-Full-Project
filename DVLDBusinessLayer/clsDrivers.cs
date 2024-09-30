using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDrivers
    {
        public int ID {  get; set; }
        public int PersonID {  get; set; }
        public int CreatedByUserID {  get; set; }
        public DateTime CreatedDate { get; set; }

        enum enMode { AddDriver,UpdateDriver};
        enMode Mode;
        public clsDrivers()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddDriver;
        }

        private clsDrivers(int ID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.ID=ID;
            this.PersonID=PersonID;
            this.CreatedByUserID=CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.UpdateDriver;
        }

        static  public clsDrivers Find(int DriverID)
        {
           
            int PersonID=-1;
            int CreatedByUserID=-1;
            DateTime CreatedDate=DateTime.Now;

            if (clsDriversDataAccess.Find(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
            {
                return new clsDrivers(DriverID,PersonID,CreatedByUserID,CreatedDate);
            }
            else
            {
                return null;
            }
        }

        static public bool IsDriverExist(int DriverID)
        {
            return clsDriversDataAccess.IsDriverExist(DriverID);
        }

        private bool _AddDriver()
        {
            this.ID = clsDriversDataAccess.AddDriver(this.PersonID,this.CreatedByUserID,this.CreatedDate);

            return (this.ID != -1);

        }
        private bool _UpdateDriver()
        {
            return clsDriversDataAccess.UpdateDriver(this.ID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddDriver:
                    return _AddDriver();
                    break;
                case enMode.UpdateDriver:
                    return _UpdateDriver();
                    break;
                default:
                    return false;
            }


        }


        static public bool DeleteDriver(int DriverID)
        {
            return clsDriversDataAccess.DeleteDriver(DriverID);
        }

        static public DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }

        static public DataTable GetAllDriversInfo()
        {
            return clsDriversDataAccess.GetAllDriversInfo();
        }

    }
}
