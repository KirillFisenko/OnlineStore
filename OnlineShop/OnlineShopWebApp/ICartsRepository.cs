using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface ICartsRepository
	{
		void Add(Product product, string userId);
		void Del(Product product, string userId);
		Cart TryGetByUserId(string userId);
	}
}