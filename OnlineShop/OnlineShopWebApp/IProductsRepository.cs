using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IProductsRepository
	{
		List<Product> GetAll();
		Product TryGetById(int id);
        Product TryGetByName(string name);
        void Del(int id);
        void Add(Product product);
        void Edit(Product product, int productId);        
    }
}