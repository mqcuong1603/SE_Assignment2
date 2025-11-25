using System;
using System.Data;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class ItemBLL
    {
        private ItemDAO itemDAO;

        public ItemBLL()
        {
            itemDAO = new ItemDAO();
        }

        public DataTable GetAllItems()
        {
            return itemDAO.GetAllItems();
        }

        public DataTable GetActiveItems()
        {
            return itemDAO.GetActiveItems();
        }

        public Item GetItemById(int itemId)
        {
            if (itemId <= 0)
                throw new Exception("Invalid Item ID");

            return itemDAO.GetItemById(itemId);
        }

        public bool InsertItem(Item item)
        {
            ValidateItem(item);
            return itemDAO.InsertItem(item);
        }

        public bool UpdateItem(Item item)
        {
            if (item.ItemID <= 0)
                throw new Exception("Invalid Item ID");

            ValidateItem(item);
            return itemDAO.UpdateItem(item);
        }

        public bool DeleteItem(int itemId)
        {
            if (itemId <= 0)
                throw new Exception("Invalid Item ID");

            return itemDAO.DeleteItem(itemId);
        }

        public DataTable SearchItems(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllItems();

            return itemDAO.SearchItems(searchText);
        }

        public DataTable GetBestSellingItems()
        {
            return itemDAO.GetBestSellingItems();
        }

        public DataTable GetItemsByAgent(int agentId)
        {
            if (agentId <= 0)
                throw new Exception("Invalid Agent ID");

            return itemDAO.GetItemsByAgent(agentId);
        }

        private void ValidateItem(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.ItemName))
                throw new Exception("Item name is required");

            if (item.Price < 0)
                throw new Exception("Price cannot be negative");

            if (item.StockQuantity < 0)
                throw new Exception("Stock quantity cannot be negative");
        }
    }
}
