using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLicenseClasses
    {
  
        public int ID { get;set;}
        public string ClassName { get;set;}
        public string ClassDescription { get;set;}
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees {  get; set; }


        public clsLicenseClasses()
        {
            ID = 0;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
        }

        private clsLicenseClasses(int LicenseClassID,string ClassName, string ClassDescription, int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees)
        {
            this.ID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        static public clsLicenseClasses Find(int ID)
        {

            string ClassName = "";
            string ClassDescription = "";
            int MinimumAllowedAge = 0;
            int DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassesDataAccess.Find(ID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength,ref ClassFees))
            {
                return new clsLicenseClasses(ID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }

        }

        private bool _UpdateLicenseClasse()
        {

            return clsLicenseClassesDataAccess.UpdateLicenseClass(this.ID, this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength,this.ClassFees);
        }
        public bool Save()
        {
            return _UpdateLicenseClasse();
        }


        static public DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }

    }
}
