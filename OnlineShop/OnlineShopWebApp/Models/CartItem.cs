namespace OnlineShopWebApp.Models
{
	public class CartItem
	{
		public Guid Id { get; set; }
		public Product? Product { get; set; }

		public int Quantity { get; set; }

		public decimal? Amount
		{
			get
			{
				return Product?.Cost * Quantity;
			}
		}
	}
}