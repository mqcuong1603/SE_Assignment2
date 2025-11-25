using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DatabaseConnection
    {
        private static string connectionString;

        static DatabaseConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["OrderManagementDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=localhost;Database=OrderManagementDB;Integrated Security=True;";
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
