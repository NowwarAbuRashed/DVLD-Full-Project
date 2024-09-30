using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsApplicationTypes
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public decimal Fees {  get; set; }

        public clsApplicationTypes() 
        { 
            ID = -1;
            Title = string.Empty;
            Fees = 0;
        }

        private clsApplicationTypes(int ID, string Title, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }

      static  public clsApplicationTypes Find(int ID)
        {
          
            string Title = string.Empty;
            decimal Fees = 0;

            if(clsApplicationTypesDataAccess.Find(ID,ref Title,ref Fees))
            {
                return new clsApplicationTypes(ID, Title, Fees);
            }
            else
            {
                return null;
            }

        }

        private bool _UpdateAplicationType()
        {

            return clsApplicationTypesDataAccess.UpdateApplicationTypes(this.ID,this.Title,this.Fees);
        }
        public bool Save()
        {
            return _UpdateAplicationType();
        }

      static  public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }
    }
}
