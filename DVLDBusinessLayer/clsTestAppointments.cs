using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTestAppointments
    {
        public int ID { get; set; }
        public int TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        enum enMode { Add, Update }
        enMode Mode;

        public clsTestAppointments() 
        {
            this.ID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;

            Mode = enMode.Add;

        }
        private clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            this.ID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            Mode = enMode.Update;

        }

        static public clsTestAppointments Find(int TestAppointmentID)
        {

            int TestTypeID=-1;
            int LocalDrivingLicenseApplicationID=-1;
            DateTime AppointmentDate=DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;
            bool IsLocked=false;

            if (clsTestAppointmentsDataAccess.Find(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID,ref IsLocked))
            {
                return new clsTestAppointments(TestAppointmentID,  TestTypeID,  LocalDrivingLicenseApplicationID,  AppointmentDate, PaidFees, CreatedByUserID,  IsLocked);
            }
            else
            {
                return null;
            }
        }



        private bool _AddTestAppointment()
        {
            this.ID = clsTestAppointmentsDataAccess.AddTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked);

            return (this.ID != -1);

        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.ID,this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    return _AddTestAppointment();
                    break;
                case enMode.Update:
                    return _UpdateTestAppointment();
                    break;
                default:
                    return false;
            }


        }

        static public DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointments();
        }

        static public DataTable GetAllTestAppointmentsInfo()
        {
            return clsTestAppointmentsDataAccess.GetAllTestAppointmentsInfo();
        }
    }
}
