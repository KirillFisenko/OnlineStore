using Microsoft.AspNetCore.Http;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IProductsRepository
	{
		List<Product> GetAll();
		Product TryGetById(Guid id);
        Product TryGetByName(string name);
        void Remove(Guid id);
        void Add(Product product);
        void Edit(Product product, IFormFile[] uploadedFiles);        
    }
}