using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    // интерфейс заказов
    public interface IOrdersRepository
    {
        // получить все заказы
        Task<List<Order>> GetAllAsync();

        // получить заказ по id
        Task<Order> TryGetByIdAsync(Guid orderId);

        // добавить заказ
        Task AddAsync(Order order);

        // обновить статус заказа
        Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}