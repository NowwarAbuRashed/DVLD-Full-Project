using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsPepole
    {
       public int ID { set; get; }
        public string NationalNo { set;get; }   

        
        public string FirstName{set; get; } 
        public string SecondName{set; get; } 
        public string ThirdName{set; get; } 
        public string LastName { set; get; }

        public DateTime DateOfBirth { set; get; }

        public byte Gendor {  set; get; }
        public string Address {  set; get; }

        public string Phone {  set; get; }
        public string Email {  set; get; }
        public int NationalityCountryID {  set; get; }

        public string ImagePath {  set; get; }

        private enum enMode { _Add,_Update}
        enMode Mode = enMode._Add;

      public   clsPepole()
        {
            this.ID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode._Add;
        }

      private  clsPepole(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode._Update;
        }

        static public clsPepole Find(int PersonID)
        {

            string NationalNo="";
            string FirstName="";
            string SecondName= "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth=DateTime.Now;
            byte Gendor =1;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID=90;
            string ImagePath = "";

            if (clsPersonDataAccess.Find(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address,
                ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPepole(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath); 
            }
            else
            {
                return null;
            }
        }
        
        static public bool IsPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccess.DeletePerson(PersonID);
        }
        private bool _AddPerson()
        {
            this.ID= clsPersonDataAccess.AddPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone,this.Email,this.NationalityCountryID,this.ImagePath);
            
            return (this.ID != -1);
            
        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode._Add:
                    return _AddPerson();
                    break;
                    case enMode._Update:
                    return _UpdatePerson(); 
                    break;
                default:
                    return false;
            }


        }

        static public DataTable GetPerson(int PersonID)
        {
            return clsPersonDataAccess.GetPerson(PersonID);
        }

        static public DataTable GetAllPersons()
        {
            return clsPersonDataAccess.GetAllPersons();
        }
        static public DataTable GetAllShortPersonsInfo()
        {
            return clsPersonDataAccess.GetAllShortPersonsInfo();
        }

    }
}
