using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface ICompare
	{
		void Add(Product product);
		void Clear();
		void Del(Product product);
		List<Product> GetAllCompare();
	}
}