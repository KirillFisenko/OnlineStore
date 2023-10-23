namespace OnlineShop.Db.Models
{
    // модель позиции в корзине в БД содержит продукт и его количество
    public class CartItem
	{
		public Guid Id { get; set; }
		public Product? Product { get; set; }		
		public int Quantity { get; set; }
	}
}