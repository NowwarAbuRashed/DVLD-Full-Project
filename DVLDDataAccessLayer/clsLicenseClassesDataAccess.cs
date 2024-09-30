using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsLicenseClassesDataAccess
    {

        static public bool Find(int LicenseClassID,ref string ClassName,ref string ClassDescription,ref int MinimumAllowedAge,ref int DefaultValidityLength,ref decimal ClassFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string Query = "Select * from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = (decimal)reader["ClassFees"];
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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = "Select * From LicenseClasses";
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



        static public bool UpdateLicenseClass(int LicenseClassID,  string ClassName,  string ClassDescription,  int MinimumAllowedAge,  int DefaultValidityLength,  decimal ClassFees)
        {
            bool ISUpdate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"Update  LicenseClasses  set
ClassName=@ClassName,
ClassDescription=@ClassDescription,
MinimumAllowedAge=@MinimumAllowedAge,
DefaultValidityLength=@DefaultValidityLength,
ClassFees=@ClassFees
Where LicenseClassID=@LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


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








    }
}
