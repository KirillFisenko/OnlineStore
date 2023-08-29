using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAllOrders();
        Order TryGetById(Guid id);
        void UpdateOrderStatus(Guid id, OrderStatuses NewStatus);
    }
}