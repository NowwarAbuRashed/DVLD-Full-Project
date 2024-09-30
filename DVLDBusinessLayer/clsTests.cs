using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBusinessLayer
{
    public class clsTests
    {
        public int ID {  get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult {  get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID {  get; set; }

        public clsTests() 
        {
            this.ID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
        }

        private clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.ID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

        }

        static public clsTests Find(int TestID)
        {


            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestsDataAccess.Find(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        private bool _AddTest()
        {
            this.ID = clsTestsDataAccess.AddTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.ID != -1);

        }

        public bool Save()
        {
            return _AddTest();

        }

        static public DataTable GetAllTests()
        {
            return clsTestsDataAccess.GetAllTests();
        }


    }
}
