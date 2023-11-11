namespace OnlineShop.Db.Models
{
    // модель карточки товара в БД 
    public class CartItem
	{
		public Guid Id { get; set; }

		// продукт
		public Product? Product { get; set; }

		// количество продукта
		public int Quantity { get; set; }
	}
}