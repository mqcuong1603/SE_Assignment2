using System;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public User Authenticate(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT UserID, UserName, Email, Password, IsLocked, Role, CreatedDate, LastLogin
                                   FROM Users
                                   WHERE UserName = @UserName AND Password = @Password AND IsLocked = 0";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString(),
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                            Role = reader["Role"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            LastLogin = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null
                        };

                        reader.Close();
                        UpdateLastLogin(user.UserID);
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user: " + ex.Message);
            }

            return null;
        }

        private void UpdateLastLogin(int userId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Users SET LastLogin = @LastLogin WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT UserID, UserName, Email, Role, IsLocked, CreatedDate, LastLogin FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting users: " + ex.Message);
            }
        }
    }
}
