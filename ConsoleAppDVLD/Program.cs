
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDVLD
{
    internal class Program
    {

        static void AddPerson()
        {
            clsPepole person = new clsPepole();
            person.NationalNo = "n5";
            person.FirstName = "Nowwar";
            person.SecondName = "Belal";
            person.ThirdName = "Frhan";
            person.LastName = "Abu Rashed";
            person.DateOfBirth = DateTime.Now;
            person.Gendor = 0;
            person.Address = "Irbed ....";
            person.Phone = "45678933";
            person.Email = "noww@gmail.com";
            person.NationalityCountryID = 90;
            person.ImagePath = "";
            if (person.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }
        static void FindPerson()
        {
            clsPepole person = clsPepole.Find(1);
            if (person != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(person.FirstName);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }
        static void PersonISExesst()
        {

            if (clsPepole.IsPersonExist(1026))
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }
        static void UpdatePerson()
        {
            clsPepole person = clsPepole.Find(1026);
            if (person != null)
            {
                person.Address = "Amman";

                if (person.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void DeletePerson()
        {
            if (clsPepole.DeletePerson(1026))
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void GetPerson()
        {
            DataTable dt = clsPepole.GetPerson(1);
            DataRow dataRow = dt.Rows[0];
            Console.WriteLine(dataRow["FirstName"]);

        }

        static void GetAllPersons()
        {
            DataTable dt = clsPepole.GetAllPersons();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["FirstName"]);
            }
        }


        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>

        static void GetAllCountres()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["CountryName"]);
            }

        }

        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void FindUser()
        {
            clsUsers user = clsUsers.Find(1);
            if (user != null)
            {
                Console.WriteLine(user.UserName);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }


        static void IsUserExist()
        {

            if (clsUsers.IsUserExist(15))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        static void AddUser()
        {
            clsUsers User = new clsUsers();
            User.UserName = "dddd";
            User.Password = "1111";
            User.IsActive = true;
            User.PersonID = 2074;


            if (User.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }
        static void UpdateUser()
        {
            clsUsers user = clsUsers.Find(16);
            if (user != null)
            {
                user.UserName = "Aiman";

                if (user.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void GetUser()
        {
            DataTable dt = clsUsers.GetUser(1);
            DataRow dataRow = dt.Rows[0];
            Console.WriteLine(dataRow["UserName"]);

        }

        static void GetAllUsers()
        {
            DataTable dt = clsUsers.GetAllUsers();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["UserName"]);
            }
        }

        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void FindDriver()
        {
            clsDrivers driver = clsDrivers.Find(9);
            if (driver != null)
            {
                Console.WriteLine(driver.PersonID);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        static void IsDriverExist()
        {

            if (clsDrivers.IsDriverExist(8))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        static void AddDriver()
        {
            clsDrivers drivers = new clsDrivers();
            drivers.PersonID = 1027;
            drivers.CreatedByUserID = 16;
            drivers.CreatedDate = DateTime.Now;


            if (drivers.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }
        static void UpdateDriver()
        {
            clsDrivers drivers = clsDrivers.Find(10);
            if (drivers != null)
            {
                drivers.PersonID = 1023;

                if (drivers.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void DeleteDriver()
        {
            if (clsDrivers.DeleteDriver(10))
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }
        static void GetAllDrivers()
        {
            DataTable dt = clsDrivers.GetAllDrivers();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["PersonID"]);
            }
        }


        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void FindApplicationTypes()
        {
            clsApplicationTypes ApplicationType = clsApplicationTypes.Find(1);
            if (ApplicationType != null)
            {
                Console.WriteLine(ApplicationType.Title.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        static void UpdateApplicationType()
        {
            clsApplicationTypes ApplicationType = clsApplicationTypes.Find(1);
            if (ApplicationType != null)
            {
                ApplicationType.Fees = 15;

                if (ApplicationType.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void FindApplication()
        {
            clsApplications Application = clsApplications.Find(61);
            if (Application != null)
            {
                Console.WriteLine(Application.PaidFees.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        static void AddApplication()
        {
            clsApplications applications = new clsApplications();
            applications.ApplicationPersonID = 3027;
            applications.ApplicationDate = DateTime.Now;
            applications.ApplicationTypeID = 3;
            applications.ApplicationStatus = 1;
            applications.lastStatusDate = DateTime.Now;
            applications.PaidFees = 1500;
            applications.CreatedByUserID = 1;

            if (applications.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void GetAllApplication()
        {
            DataTable dt = clsApplications.GetAllApplications();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["ApplicationID"]);
            }
        }


        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void FindLicenseClasses()
        {
            clsLicenseClasses licenseClasses = clsLicenseClasses.Find(1);
            if (licenseClasses != null)
            {
                Console.WriteLine(licenseClasses.ClassName.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        static void UpdateLicenseClasses()
        {
            clsLicenseClasses licenseClasses = clsLicenseClasses.Find(1);
            if (licenseClasses != null)
            {
                licenseClasses.ClassFees = 15;

                if (licenseClasses.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void GetAllLicenseClasses()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["ClassName"]);
            }
        }


        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void AddlocalDrivingLicenseApplications()
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();

            localDrivingLicenseApplications.ApplicationID = 68;
            localDrivingLicenseApplications.LicenseClassID = 7;

            if (localDrivingLicenseApplications.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void FindlocalDrivingLicenseApplication()
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(30);
            if (localDrivingLicenseApplications != null)
            {
                Console.WriteLine(localDrivingLicenseApplications.LicenseClassID.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        static void GetAlllocalDrivingLicenseApplication()
        {
            DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["LicenseClassID"]);
            }
        }

        static void GetAllLocalDrivingLicenseApplicationsInfo()
        {
            DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationsInfo();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["Classname"]);
            }
        }



        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="args"></param>
        /// 



        static void FindTestAppointment()
        {
            clsTestAppointments testAppointments = clsTestAppointments.Find(66);
            if (testAppointments != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(testAppointments.PaidFees);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void AddTestAppointment()
        {
            clsTestAppointments testAppointments = new clsTestAppointments();

            testAppointments.TestTypeID = 1;
            testAppointments.LocalDrivingLicenseApplicationID = 46;
            testAppointments.AppointmentDate = DateTime.Now;
            testAppointments.PaidFees = 30;
            testAppointments.CreatedByUserID = 1;
            testAppointments.IsLocked = false;

            if (testAppointments.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }
       
        static void UpdateTestAppointment()
        {
            clsTestAppointments testAppointments = clsTestAppointments.Find(72);
            if (testAppointments != null)
            {
                testAppointments.IsLocked=true;

                if (testAppointments.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }


        static void GetAllTestAppointments()
        {
            DataTable dt = clsTestAppointments.GetAllTestAppointments();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["TestAppointmentID"]);
            }
        }

        static void GetAllTestAppointmentsInfo()
        {
            DataTable dt = clsTestAppointments.GetAllTestAppointmentsInfo();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["TestTypeTitle"]);
            }
        }



        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void FindTest()
        {
           clsTests tests = clsTests.Find(30);
            if (tests != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(tests.TestAppointmentID);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void AddTest()
        {
            clsTests tests = new clsTests();

            tests.TestAppointmentID = 71;
            tests.TestResult = true;
            tests.Notes = string.Empty;
            tests.CreatedByUserID = 1;
           

            if (tests.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        


        static void GetAllTests()
        {
            DataTable dt = clsTests.GetAllTests();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["TestAppointmentID"]);
            }
        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="args"></param>






        static void FindLicenses()
        {
           clsLicenses licenses = clsLicenses.Find(11);
            if (licenses != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(licenses.ApplicationID);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void AddLicenses()
        {
            clsLicenses licenses = new clsLicenses();

            licenses.ApplicationID = 67;
            licenses.DriverID = 9;
            licenses.LicenseClass = 3;
            licenses.IssueDate = DateTime.Now;
            licenses.ExpirationDate = DateTime.Now;
            licenses.Notes = "";
            licenses.PaidFees = 22;
            licenses.IsActive = false;
            licenses.IssueReason = 2;
            licenses.CreatedByUserID = 1;


            if (licenses.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void GetAllLicenses()
        {
            DataTable dt = clsLicenses.GetAllLicensess();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["LicenseID"]);
            }
        }




        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="args"></param>




        static void FindDetainedLicenses()
        {
           clsDetainedLicenses detainedLicenses = clsDetainedLicenses.Find(6);
            if (detainedLicenses != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(detainedLicenses.LicenseID);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void AddDetainedLicenses()
        {
            clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();
            detainedLicenses.LicenseID = 15;
            detainedLicenses.DetainDate = DateTime.Now;
            detainedLicenses.FineFees = 90;
            detainedLicenses.CreatedByUserID = 1;



            if (detainedLicenses.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }

        static void GetAllDetainedLicenses()
        {
            DataTable dt = clsDetainedLicenses.GetAllDetainedLicenses();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["LicenseID"]);
            }
        }




        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void FindInternationalLicense()
        {
            clsInternationalLicenses internationalLicenses = clsInternationalLicenses.Find(12);
            if (internationalLicenses != null)
            {
                Console.WriteLine("Saccessfuly");
                Console.WriteLine(internationalLicenses.ApplicationID);
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        static void AddDInternationalLicense()
        {
          clsInternationalLicenses internationalLicenses =new clsInternationalLicenses();

            internationalLicenses.ApplicationID = 69;
            internationalLicenses.DriverID = 9;
            internationalLicenses.IssuedUsingLocalLicenseID = 17;
            internationalLicenses.IssueDate = DateTime.Now;
            internationalLicenses.ExpirationDate = DateTime.Now;    
            internationalLicenses.IsActive = false;
            internationalLicenses.CreatedByUserID = 1;



            if (internationalLicenses.Save())
            {
                Console.WriteLine("Saccessfuly");
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }


        static void UpdateInternationalLicense()
        {
            clsInternationalLicenses internationalLicenses = clsInternationalLicenses.Find(14);
            if (internationalLicenses != null)
            {
                internationalLicenses.IsActive = true;

                if (internationalLicenses.Save())
                {
                    Console.WriteLine("Saccessfuly");
                }
                else
                {
                    Console.WriteLine("Faild");
                }
            }
            else
            {
                Console.WriteLine("Faild");
            }

        }


        static void GetAllInternationalLicense()
        {
            DataTable dt = clsInternationalLicenses.GetAllInternationalLicenses();

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow["ApplicationID"]);
            }
        }






        static void Main(string[] args)
        {
            //New Local Driving License Service   15
            {
                // AddPerson();
                // FindPerson();
                // UpdatePerson();
                // DeletePerson();
                // PersonISExesst();
                // GetPerson();
                //  GetAllPersons();

                ////////////////////////////////////
                ////////////////////////////////////
                ////////////////////////////////////
                ////////////////////////////////////

            }

            {   //GetAllCountres();

                //  FindUser();

                //   IsUserExist();

                //    AddUser();
                //   UpdateUser();

                //    GetUser();
                //  GetAllUsers();
            }

            {// FindDriver();
             //  IsDriverExist();
             //  AddDriver();
             //UpdateDriver();
             // DeleteDriver();


                // GetAllDrivers();
            }

            {

                //  FindApplicationTypes();

                //    UpdateApplicationType();
            }

            {//            FindApplication();
             //  AddApplication();}

           // GetAllApplication();


            }

            {
                // FindLicenseClasses();
              //  UpdateLicenseClasses();
               // GetAllLicenseClasses();
            }

            {
                // AddlocalDrivingLicenseApplications();
                //FindlocalDrivingLicenseApplication();
                // GetAlllocalDrivingLicenseApplication();
               // GetAllLocalDrivingLicenseApplicationsInfo();

            }

            {
                // FindTestAppointment();
                //AddTestAppointment();
                // UpdateTestAppointment();
              //  GetAllTestAppointments();
               // GetAllTestAppointmentsInfo();
            }

            {
                // FindTest();
              //  AddTest();

              //  GetAllTests();

             
            }

            {
                //  FindLicenses();
                //AddLicenses();
              //  GetAllLicenses();
            }

            {
                //FindDetainedLicenses();
                // AddDetainedLicenses();
               // GetAllDetainedLicenses();
            }


            {
                //   FindInternationalLicense();
                //AddDInternationalLicense();
                // UpdateInternationalLicense();
               // GetAllInternationalLicense();

            }

            Console.ReadLine();



        }
    }
}
