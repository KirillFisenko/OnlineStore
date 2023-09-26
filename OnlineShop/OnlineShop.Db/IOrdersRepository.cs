﻿using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid id, OrderStatuses newStatus);
    }
}