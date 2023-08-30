﻿using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private readonly List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order TryGetById(Guid orderId)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            return order;
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatuses newStatus)
        {
            var order = TryGetById(orderId);
            order.Status = newStatus;
        }
    }
}