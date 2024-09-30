using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsPersonDataAccess
    {

        private static void _CheckIsNull(ref SqlCommand Command, string NameFeald, ref string Value)
        {
            if (Value != ""&& Value!=string.Empty && Value!=null)
                Command.Parameters.AddWithValue(NameFeald, Value);
            else
                Command.Parameters.AddWithValue(NameFeald, System.DBNull.Value);
        }

        static public bool Find(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFind=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = "Select * from People where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"].ToString();
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"].ToString();
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = (string)reader["ImagePath"].ToString();

                    IsFind=true;
                    reader.Close();

                }
                else
                {
                    IsFind=false;
                }
           


            }
            catch(Exception ex)
            {


            }
            finally { connection.Close(); }

            return IsFind;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select found=1 from People Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }

            return IsFound;
        }

        static public int AddPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID=-1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = @"INSERT INTO People(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
VALUES(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
SELECT SCOPE_IDENTITY();";

            SqlCommand command =new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            _CheckIsNull(ref command, "@ThirdName", ref ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            _CheckIsNull(ref command, "@Email", ref Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            _CheckIsNull(ref command, "@ImagePath",ref ImagePath);
            try
            {
                connection.Open();

                object Result= command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(),out int InsertedID))
                {
                    PersonID= InsertedID;
                }
                
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }


            return PersonID;
        }

        static public bool UpdatePerson(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            bool ISUpdate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"Update  People  set
NationalNo=@NationalNo,
FirstName=@FirstName,
SecondName=@SecondName,
ThirdName=@ThirdName,
LastName=@LastName,
DateOfBirth=@DateOfBirth,
Gendor=@Gendor,
Address=@Address,
Phone=@Phone,
Email=@Email,
NationalityCountryID=@NationalityCountryID,
ImagePath=@ImagePath
Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            _CheckIsNull(ref command, "@ThirdName", ref ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            _CheckIsNull(ref command, "@Email", ref Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            _CheckIsNull(ref command, "@ImagePath", ref ImagePath);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                ISUpdate = true;

            }
            catch (Exception ex)
            {
                ISUpdate = false;

            }
            finally { connection.Close(); }



            return ISUpdate;
        }


        public static bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Delete From People Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                IsDeleted = true;
            }
            catch (Exception ex)
            {
                IsDeleted = false;
            }
            finally { connection.Close(); }

            return IsDeleted;

        }

        public static DataTable GetPerson(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From People Where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;




        }
        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From People";
            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;




        }
        public static DataTable GetAllShortPersonsInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From PersonsShortInfo";
            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;


        }

    }
}
