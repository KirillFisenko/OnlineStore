using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IProductsRepository
	{
		List<Product> GetAllProducts();
		Product TryGetById(int id);
        void Del(int id);
        void Add(Product product);
        void Update(Product product);        
    }
}