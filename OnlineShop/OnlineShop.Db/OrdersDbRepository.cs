using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.ToList();
        }

        public Order TryGetById(Guid orderId)
        {
            var order = databaseContext.Orders.FirstOrDefault(o => o.Id == orderId);
            return order;
        }

        public void UpdateStatus(Guid orderId, OrderStatuses newStatus)
        {
            var order = TryGetById(orderId);
            order.Status = newStatus;
            databaseContext.SaveChanges();
        }
    }
}