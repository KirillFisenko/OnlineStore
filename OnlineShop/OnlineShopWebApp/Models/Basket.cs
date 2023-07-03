namespace OnlineShopWebApp.Models
{
	public class Basket
	{
		public User UserBasket { get; set; }
		public List<Product> ProductsInBasket { get; set; }

		public Basket(User userBasket, List<Product> productsInBasket) 
		{ 
			UserBasket = userBasket;
			ProductsInBasket = productsInBasket;
		}
	}
}