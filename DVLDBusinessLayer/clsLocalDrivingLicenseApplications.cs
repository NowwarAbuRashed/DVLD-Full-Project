using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplications
    { 
        
        public int ID {  get; set; }

        public int ApplicationID {  get; set; }

        public int LicenseClassID { get; set; }

       
     public   clsLocalDrivingLicenseApplications()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }
      private  clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID,int LicenseClassID)
        {
            this.ID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        static public clsLocalDrivingLicenseApplications Find(int ID)
        {

            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsDataAccess.Find(ID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplications(ID, ApplicationID, LicenseClassID);
            }
            else
            {
                return null;
            }

        }
        private bool _AddLocalDrivingLicenseApplication()
        {
            this.ID = clsLocalDrivingLicenseApplicationsDataAccess.AddLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.ID != -1);
        }
        public bool Save()
        {
            return _AddLocalDrivingLicenseApplication();
        }


        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }
        static public DataTable GetAllLocalDrivingLicenseApplicationsInfo()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplicationsInfo();
        }


    }
}
