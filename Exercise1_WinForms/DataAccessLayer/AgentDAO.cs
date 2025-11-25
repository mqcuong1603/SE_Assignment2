using System;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class AgentDAO
    {
        public DataTable GetAllAgents()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Agent ORDER BY AgentID DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting agents: " + ex.Message);
            }
        }

        public DataTable GetActiveAgents()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Agent WHERE IsActive = 1 ORDER BY AgentName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting active agents: " + ex.Message);
            }
        }

        public Agent GetAgentById(int agentId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Agent WHERE AgentID = @AgentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AgentID", agentId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return MapReaderToAgent(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting agent: " + ex.Message);
            }

            return null;
        }

        public bool InsertAgent(Agent agent)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO Agent (AgentName, Address, Phone, Email, CompanyName, TaxCode, IsActive, CreatedDate)
                                   VALUES (@AgentName, @Address, @Phone, @Email, @CompanyName, @TaxCode, @IsActive, @CreatedDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AgentName", agent.AgentName);
                    cmd.Parameters.AddWithValue("@Address", agent.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", agent.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", agent.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", agent.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxCode", agent.TaxCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", agent.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting agent: " + ex.Message);
            }
        }

        public bool UpdateAgent(Agent agent)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE Agent SET
                                   AgentName = @AgentName,
                                   Address = @Address,
                                   Phone = @Phone,
                                   Email = @Email,
                                   CompanyName = @CompanyName,
                                   TaxCode = @TaxCode,
                                   IsActive = @IsActive
                                   WHERE AgentID = @AgentID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AgentID", agent.AgentID);
                    cmd.Parameters.AddWithValue("@AgentName", agent.AgentName);
                    cmd.Parameters.AddWithValue("@Address", agent.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", agent.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", agent.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", agent.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxCode", agent.TaxCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", agent.IsActive);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating agent: " + ex.Message);
            }
        }

        public bool DeleteAgent(int agentId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Agent SET IsActive = 0 WHERE AgentID = @AgentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AgentID", agentId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting agent: " + ex.Message);
            }
        }

        public DataTable SearchAgents(string searchText)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT * FROM Agent
                                   WHERE AgentName LIKE @SearchText
                                   OR CompanyName LIKE @SearchText
                                   OR Email LIKE @SearchText
                                   OR Phone LIKE @SearchText
                                   ORDER BY AgentName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching agents: " + ex.Message);
            }
        }

        public DataTable GetTopCustomers()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM vw_TopCustomers ORDER BY TotalSpent DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting top customers: " + ex.Message);
            }
        }

        public DataTable GetAgentsByItem(int itemId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "EXEC sp_GetAgentsByItem @ItemID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", itemId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting agents by item: " + ex.Message);
            }
        }

        private Agent MapReaderToAgent(SqlDataReader reader)
        {
            return new Agent
            {
                AgentID = Convert.ToInt32(reader["AgentID"]),
                AgentName = reader["AgentName"].ToString(),
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : null,
                TaxCode = reader["TaxCode"] != DBNull.Value ? reader["TaxCode"].ToString() : null,
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
            };
        }
    }
}
