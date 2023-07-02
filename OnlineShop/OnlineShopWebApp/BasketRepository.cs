using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class BasketRepository
	{
		private static List<Basket> basket = new List<Basket>();

		public List<Basket> AddProductToBasket(Product product)
		{
			var newProductInBasket = new Basket(product.Name, 1, product.Cost);
			basket.Add(newProductInBasket);
			return basket;
		}
	}
}
