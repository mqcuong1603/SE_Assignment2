using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class OrderBLL
    {
        private OrderDAO orderDAO;
        private OrderDetailDAO orderDetailDAO;

        public OrderBLL()
        {
            orderDAO = new OrderDAO();
            orderDetailDAO = new OrderDetailDAO();
        }

        public DataTable GetAllOrders()
        {
            return orderDAO.GetAllOrders();
        }

        public DataTable GetOrderSummary()
        {
            return orderDAO.GetOrderSummary();
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId <= 0)
                throw new Exception("Invalid Order ID");

            return orderDAO.GetOrderById(orderId);
        }

        public DataTable GetOrderDetails(int orderId)
        {
            if (orderId <= 0)
                throw new Exception("Invalid Order ID");

            return orderDetailDAO.GetOrderDetailsByOrderId(orderId);
        }

        public int CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            ValidateOrder(order);

            if (orderDetails == null || orderDetails.Count == 0)
                throw new Exception("Order must have at least one item");

            decimal totalAmount = 0;
            foreach (var detail in orderDetails)
            {
                ValidateOrderDetail(detail);
                totalAmount += detail.Quantity * detail.UnitAmount * (1 - detail.Discount / 100);
            }

            order.TotalAmount = totalAmount;
            int orderId = orderDAO.InsertOrder(order);

            if (orderId > 0)
            {
                orderDetailDAO.InsertOrderDetails(orderId, orderDetails);
            }

            return orderId;
        }

        public bool UpdateOrder(Order order, List<OrderDetail> orderDetails)
        {
            if (order.OrderID <= 0)
                throw new Exception("Invalid Order ID");

            ValidateOrder(order);

            if (orderDetails == null || orderDetails.Count == 0)
                throw new Exception("Order must have at least one item");

            foreach (var detail in orderDetails)
            {
                ValidateOrderDetail(detail);
            }

            orderDetailDAO.DeleteOrderDetailsByOrderId(order.OrderID);

            bool result = orderDAO.UpdateOrder(order);

            if (result)
            {
                orderDetailDAO.InsertOrderDetails(order.OrderID, orderDetails);
            }

            return result;
        }

        public bool DeleteOrder(int orderId)
        {
            if (orderId <= 0)
                throw new Exception("Invalid Order ID");

            return orderDAO.DeleteOrder(orderId);
        }

        public DataTable SearchOrders(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllOrders();

            return orderDAO.SearchOrders(searchText);
        }

        public DataTable GetOrdersByAgent(int agentId)
        {
            if (agentId <= 0)
                throw new Exception("Invalid Agent ID");

            return orderDAO.GetOrdersByAgent(agentId);
        }

        public DataTable GetOrdersByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new Exception("Status is required");

            return orderDAO.GetOrdersByStatus(status);
        }

        private void ValidateOrder(Order order)
        {
            if (order.AgentID <= 0)
                throw new Exception("Please select an agent");

            if (order.OrderDate == default(DateTime))
                order.OrderDate = DateTime.Now;
        }

        private void ValidateOrderDetail(OrderDetail detail)
        {
            if (detail.ItemID <= 0)
                throw new Exception("Invalid Item");

            if (detail.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            if (detail.UnitAmount < 0)
                throw new Exception("Unit amount cannot be negative");

            if (detail.Discount < 0 || detail.Discount > 100)
                throw new Exception("Discount must be between 0 and 100");
        }
    }
}
