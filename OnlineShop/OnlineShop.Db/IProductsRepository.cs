using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Db
{
	public interface IProductsRepository
	{
		List<Product> GetAll();
		Product TryGetById(Guid id);
        Product TryGetByName(string name);
        void Del(Guid id);
        void Add(Product product);
        void Edit(Product product, Guid productId);        
    }
}