using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        public DataTable GetOrderDetailsByOrderId(int orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT od.ID, od.OrderID, od.ItemID, i.ItemName, i.Size,
                                   od.Quantity, od.UnitAmount, od.Discount, od.TotalAmount
                                   FROM OrderDetail od
                                   INNER JOIN Item i ON od.ItemID = i.ItemID
                                   WHERE od.OrderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting order details: " + ex.Message);
            }
        }

        public List<OrderDetail> GetOrderDetailsListByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT od.ID, od.OrderID, od.ItemID, i.ItemName, i.Size,
                                   od.Quantity, od.UnitAmount, od.Discount, od.TotalAmount
                                   FROM OrderDetail od
                                   INNER JOIN Item i ON od.ItemID = i.ItemID
                                   WHERE od.OrderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        orderDetails.Add(MapReaderToOrderDetail(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting order details: " + ex.Message);
            }

            return orderDetails;
        }

        public bool InsertOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount, Discount)
                                   VALUES (@OrderID, @ItemID, @Quantity, @UnitAmount, @Discount)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                    cmd.Parameters.AddWithValue("@ItemID", orderDetail.ItemID);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitAmount", orderDetail.UnitAmount);
                    cmd.Parameters.AddWithValue("@Discount", orderDetail.Discount);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting order detail: " + ex.Message);
            }
        }

        public bool InsertOrderDetails(int orderId, List<OrderDetail> orderDetails)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                foreach (var detail in orderDetails)
                {
                    string query = @"INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount, Discount)
                                   VALUES (@OrderID, @ItemID, @Quantity, @UnitAmount, @Discount)";

                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@ItemID", detail.ItemID);
                    cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitAmount", detail.UnitAmount);
                    cmd.Parameters.AddWithValue("@Discount", detail.Discount);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw new Exception("Error inserting order details: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE OrderDetail SET
                                   ItemID = @ItemID,
                                   Quantity = @Quantity,
                                   UnitAmount = @UnitAmount,
                                   Discount = @Discount
                                   WHERE ID = @ID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", orderDetail.ID);
                    cmd.Parameters.AddWithValue("@ItemID", orderDetail.ItemID);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitAmount", orderDetail.UnitAmount);
                    cmd.Parameters.AddWithValue("@Discount", orderDetail.Discount);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order detail: " + ex.Message);
            }
        }

        public bool DeleteOrderDetail(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM OrderDetail WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order detail: " + ex.Message);
            }
        }

        public bool DeleteOrderDetailsByOrderId(int orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM OrderDetail WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order details: " + ex.Message);
            }
        }

        private OrderDetail MapReaderToOrderDetail(SqlDataReader reader)
        {
            return new OrderDetail
            {
                ID = Convert.ToInt32(reader["ID"]),
                OrderID = Convert.ToInt32(reader["OrderID"]),
                ItemID = Convert.ToInt32(reader["ItemID"]),
                ItemName = reader["ItemName"].ToString(),
                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : null,
                Quantity = Convert.ToInt32(reader["Quantity"]),
                UnitAmount = Convert.ToDecimal(reader["UnitAmount"]),
                Discount = Convert.ToDecimal(reader["Discount"]),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
            };
        }
    }
}
