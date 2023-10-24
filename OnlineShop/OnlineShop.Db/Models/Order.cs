namespace OnlineShop.Db.Models
{
    // модель заказа в БД
    public class Order
    {
        public Guid Id { get; set; }

        // данные заказчика
        public UserDeliveryInfo? User { get; set; }

        // список карточек товара
        public List<CartItem>? Items { get; set; }

        // статус заказа
		public OrderStatus Status { get; set; }

        // дата создания заказа
		public DateTime CreateDateTime { get; set; }        

        public Order()
        {
            // начальный статус заказа - создан
			Status = OrderStatus.Created;

			// устанавливаем время содания заказа - время данного компьютера
			CreateDateTime = DateTime.Now;			
		}
    }
}