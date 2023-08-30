using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IProductsRepository
	{
		List<Product> GetAllProducts();
		Product TryGetById(int id);
        Product TryGetByName(string name);
        void Del(int id);
        void Add(Product product);
        void Update(Product product, int productId);        
    }
}