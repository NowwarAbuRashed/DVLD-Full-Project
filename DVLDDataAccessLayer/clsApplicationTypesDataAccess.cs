using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class clsApplicationTypesDataAccess
    {
        static public bool Find(int ApplicationTypeID, ref string  Title,ref decimal Fees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = "Select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];
                  
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

        static public bool UpdateApplicationTypes(int ApplicationID, string Title, decimal Fees)
        {
            bool ISUpdate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"Update  ApplicationTypes  set
ApplicationTypeTitle=@ApplicationTypeTitle,
ApplicationFees=@ApplicationFees
Where ApplicationTypeID=@ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);


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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From ApplicationTypes";
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
