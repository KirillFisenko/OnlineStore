using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    // репозиторий заказов в БД
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        // получить все заказы
		public async Task<List<Order>> GetAllAsync()
		{
			return await databaseContext.Orders
				.Include(x => x.User)
				.Include(x => x.Items)
				.ThenInclude(x => x.Product)
				.ToListAsync();
		}

        // получить заказ по id
		public async Task<Order> TryGetByIdAsync(Guid orderId)
		{
			return await databaseContext.Orders
				.Include(x => x.User)
				.Include(x => x.Items)
				.ThenInclude(x => x.Product)
				.FirstOrDefaultAsync(o => o.Id == orderId);
		}

        // добавить заказ
        public async Task AddAsync(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            await databaseContext.SaveChangesAsync();
        }

        // обновить статус заказа
        public async Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await TryGetByIdAsync(orderId);
            if (order != null)
            {
                order.Status = newStatus;
            }
            await databaseContext.SaveChangesAsync();
        }
    }
}