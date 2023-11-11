namespace OnlineShopWebApp.Models
{
	// модель заказа для представления
	public class OrderViewModel
    {
        public Guid Id { get; set; }

        // данные заказчика
        public UserDeliveryInfoViewModel? User { get; set; }

		// список карточек товара
		public List<CartItemViewModel>? Items { get; set; }

		// дата создания заказа
		public DateTime CreateDateTime { get; set; }

		// статус заказа
		public OrderStatusViewModel Status { get; set; }

        // автосвойство для вычисления сумы заказа
        public decimal? Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount);
            }            
        }

        public OrderViewModel()
        {            
            CreateDateTime = DateTime.Now;
            Status = OrderStatusViewModel.Created;
        }
    }
}