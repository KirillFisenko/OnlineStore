using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        public List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order TryGetById(Guid id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            return order;
        }

        public void UpdateOrderStatus(Guid id, OrderStatuses newStatus)
        {
            var order = TryGetById(id);
            order.Status = newStatus;
        }
    }
}