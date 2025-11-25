using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class ItemDAO
    {
        public DataTable GetAllItems()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Item ORDER BY ItemID DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting items: " + ex.Message);
            }
        }

        public DataTable GetActiveItems()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Item WHERE IsActive = 1 ORDER BY ItemName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting active items: " + ex.Message);
            }
        }

        public Item GetItemById(int itemId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Item WHERE ItemID = @ItemID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", itemId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return MapReaderToItem(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting item: " + ex.Message);
            }

            return null;
        }

        public bool InsertItem(Item item)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO Item (ItemName, Size, Price, StockQuantity, Category, Description, ImageUrl, IsActive, CreatedDate)
                                   VALUES (@ItemName, @Size, @Price, @StockQuantity, @Category, @Description, @ImageUrl, @IsActive, @CreatedDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@Size", item.Size ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", item.StockQuantity);
                    cmd.Parameters.AddWithValue("@Category", item.Category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImageUrl", item.ImageUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", item.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting item: " + ex.Message);
            }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE Item SET
                                   ItemName = @ItemName,
                                   Size = @Size,
                                   Price = @Price,
                                   StockQuantity = @StockQuantity,
                                   Category = @Category,
                                   Description = @Description,
                                   ImageUrl = @ImageUrl,
                                   IsActive = @IsActive
                                   WHERE ItemID = @ItemID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                    cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@Size", item.Size ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", item.StockQuantity);
                    cmd.Parameters.AddWithValue("@Category", item.Category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImageUrl", item.ImageUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", item.IsActive);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating item: " + ex.Message);
            }
        }

        public bool DeleteItem(int itemId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Item SET IsActive = 0 WHERE ItemID = @ItemID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ItemID", itemId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting item: " + ex.Message);
            }
        }

        public DataTable SearchItems(string searchText)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT * FROM Item
                                   WHERE ItemName LIKE @SearchText
                                   OR Category LIKE @SearchText
                                   OR Description LIKE @SearchText
                                   ORDER BY ItemName";

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
                throw new Exception("Error searching items: " + ex.Message);
            }
        }

        public DataTable GetBestSellingItems()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM vw_BestSellingItems ORDER BY TotalQuantitySold DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting best selling items: " + ex.Message);
            }
        }

        public DataTable GetItemsByAgent(int agentId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "EXEC sp_GetItemsByAgent @AgentID";
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
                throw new Exception("Error getting items by agent: " + ex.Message);
            }
        }

        private Item MapReaderToItem(SqlDataReader reader)
        {
            return new Item
            {
                ItemID = Convert.ToInt32(reader["ItemID"]),
                ItemName = reader["ItemName"].ToString(),
                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : null,
                Price = Convert.ToDecimal(reader["Price"]),
                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null,
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                ImageUrl = reader["ImageUrl"] != DBNull.Value ? reader["ImageUrl"].ToString() : null,
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
            };
        }
    }
}
