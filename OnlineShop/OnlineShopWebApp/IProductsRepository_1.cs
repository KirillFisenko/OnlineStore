using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IProductsRepository
	{
		void Add(Product product, string userId);
		void Clear(string userId);
		void DecreaseAmount(Product product, string userId);
		Product TryGetByUserId(string userId);
	}
}