using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsUsers
    {
        public int ID {  get; set; }
        public int PersonID {  get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public bool IsActive {  get; set; }

        enum enMode { AddUser,UpdateUser};
        enMode Mode;

      public  clsUsers() 
        {
            this.ID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            Mode=enMode.AddUser;
        }
        private clsUsers (int UserID,int PersonID,string UserName, string Password, bool IsActive)
        {
            this.ID = UserID;
            this.PersonID=PersonID;
            this.UserName=UserName;
            this.Password=Password;
            this.IsActive =IsActive;
            Mode=enMode.UpdateUser;
        }
        static public  clsUsers Find(int ID)
        {
            
            int PersonID=-1;
            string UserName="";
            string Password="";
            bool IsActive=false;

            if(clsUsersDataAccess.Find( ID,ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUsers(ID,PersonID,UserName,Password,IsActive);
            }
            else
            {
                return null;
            }

        }

        static public bool IsUserExist(int PersonID)
        {
            return clsUsersDataAccess.IsUserExist(PersonID);
        }


        private bool _AddUser()
        {
            this.ID = clsUsersDataAccess.AddUser(this.PersonID,this.UserName,this.Password,this.IsActive);

            return (this.ID != -1);

        }
        private bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.ID,this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddUser:
                    return _AddUser();
                    break;
                case enMode.UpdateUser:
                    return _UpdateUser();
                    break;
                default:
                    return false;
            }


        }

        static public bool DeleteUser(int UserID)
        {
            return clsUsersDataAccess.DeleteUser(UserID);
        }
        static public DataTable GetUser(int PersonID)
        {
            return clsUsersDataAccess.GetUser(PersonID);
        }

        static public DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }

        static public DataTable GetAllShortUserInfo()
        {
            return clsUsersDataAccess.GetAllShortUserInfo();
        }
    }
}
