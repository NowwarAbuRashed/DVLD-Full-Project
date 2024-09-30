using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsTestsDataAccess
    {
        private static void _CheckIsNull(ref SqlCommand Command, string NameFeald, ref string Value)
        {
            if (Value != "" && Value != string.Empty && Value != null)
                Command.Parameters.AddWithValue(NameFeald, Value);
            else
                Command.Parameters.AddWithValue(NameFeald, System.DBNull.Value);
        }


        static public bool Find(int TestID,ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = "Select * from Tests where TestID=@TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"].ToString();
                    CreatedByUserID = (int)reader["CreatedByUserID"];



                    IsFind = true;
                    reader.Close();

                }
                else
                {
                    IsFind = false;
                }



            }
            catch (Exception ex)
            {


            }
            finally { connection.Close(); }

            return IsFind;
        }




        static public int AddTest( int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = @"INSERT INTO Tests(TestAppointmentID, TestResult, Notes, CreatedByUserID) 
VALUES(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            _CheckIsNull(ref command,"@Notes",ref Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }


            return TestID;
        }

   


        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From Tests";
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
