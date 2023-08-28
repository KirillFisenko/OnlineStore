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
    }
}