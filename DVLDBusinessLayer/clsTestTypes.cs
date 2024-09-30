using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTestTypes
    {
        public int ID {  get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set;}
        public decimal TestTypeFees {  get; set;}

       public clsTestTypes()
        {
            this.ID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
        }
       private clsTestTypes(int TestTypeID,string TestTypeTitle,string TestTypeDescription,decimal TestTypeFees)
        {
            this.ID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        static public clsTestTypes Find(int ID)
        {

         
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (clsTestTypesDataAccess.Find(ID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestTypes(ID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }

        }

        private bool _UpdateTestType()
        {

            return clsTestTypesDataAccess.UpdateTestType(this.ID, this.TestTypeTitle, this.TestTypeDescription,this.TestTypeFees);
        }
        public bool Save()
        {
            return _UpdateTestType();
        }

        static public DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }



    }
}
