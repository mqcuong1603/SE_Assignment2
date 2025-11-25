using System;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        public DataTable GetAllOrders()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT o.OrderID, o.OrderDate, o.AgentID, a.AgentName,
                                   o.TotalAmount, o.Status, o.ShippingAddress, o.Notes, o.CreatedBy
                                   FROM [Order] o
                                   INNER JOIN Agent a ON o.AgentID = a.AgentID
                                   ORDER BY o.OrderID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting orders: " + ex.Message);
            }
        }

        public DataTable GetOrderSummary()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM vw_OrderSummary ORDER BY OrderDate DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting order summary: " + ex.Message);
            }
        }

        public Order GetOrderById(int orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT o.*, a.AgentName
                                   FROM [Order] o
                                   INNER JOIN Agent a ON o.AgentID = a.AgentID
                                   WHERE o.OrderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return MapReaderToOrder(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting order: " + ex.Message);
            }

            return null;
        }

        public int InsertOrder(Order order)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO [Order] (OrderDate, AgentID, TotalAmount, Status, ShippingAddress, Notes, CreatedBy, CreatedDate)
                                   VALUES (@OrderDate, @AgentID, @TotalAmount, @Status, @ShippingAddress, @Notes, @CreatedBy, @CreatedDate);
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@AgentID", order.AgentID);
                    cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                    cmd.Parameters.AddWithValue("@Status", order.Status ?? "Pending");
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notes", order.Notes ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", order.CreatedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    conn.Open();
                    int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newOrderId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting order: " + ex.Message);
            }
        }

        public bool UpdateOrder(Order order)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE [Order] SET
                                   OrderDate = @OrderDate,
                                   AgentID = @AgentID,
                                   Status = @Status,
                                   ShippingAddress = @ShippingAddress,
                                   Notes = @Notes
                                   WHERE OrderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@AgentID", order.AgentID);
                    cmd.Parameters.AddWithValue("@Status", order.Status ?? "Pending");
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notes", order.Notes ?? (object)DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order: " + ex.Message);
            }
        }

        public bool DeleteOrder(int orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM [Order] WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order: " + ex.Message);
            }
        }

        public DataTable SearchOrders(string searchText)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT o.OrderID, o.OrderDate, o.AgentID, a.AgentName,
                                   o.TotalAmount, o.Status, o.ShippingAddress, o.Notes
                                   FROM [Order] o
                                   INNER JOIN Agent a ON o.AgentID = a.AgentID
                                   WHERE a.AgentName LIKE @SearchText
                                   OR o.Status LIKE @SearchText
                                   OR CAST(o.OrderID AS NVARCHAR) LIKE @SearchText
                                   ORDER BY o.OrderDate DESC";

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
                throw new Exception("Error searching orders: " + ex.Message);
            }
        }

        public DataTable GetOrdersByAgent(int agentId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, o.ShippingAddress
                                   FROM [Order] o
                                   WHERE o.AgentID = @AgentID
                                   ORDER BY o.OrderDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AgentID", agentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting orders by agent: " + ex.Message);
            }
        }

        public DataTable GetOrdersByStatus(string status)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT o.OrderID, o.OrderDate, o.AgentID, a.AgentName,
                                   o.TotalAmount, o.Status, o.ShippingAddress
                                   FROM [Order] o
                                   INNER JOIN Agent a ON o.AgentID = a.AgentID
                                   WHERE o.Status = @Status
                                   ORDER BY o.OrderDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", status);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting orders by status: " + ex.Message);
            }
        }

        private Order MapReaderToOrder(SqlDataReader reader)
        {
            return new Order
            {
                OrderID = Convert.ToInt32(reader["OrderID"]),
                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                AgentID = Convert.ToInt32(reader["AgentID"]),
                AgentName = reader["AgentName"].ToString(),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                Status = reader["Status"].ToString(),
                ShippingAddress = reader["ShippingAddress"] != DBNull.Value ? reader["ShippingAddress"].ToString() : null,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                CreatedBy = reader["CreatedBy"] != DBNull.Value ? Convert.ToInt32(reader["CreatedBy"]) : (int?)null
            };
        }
    }
}
