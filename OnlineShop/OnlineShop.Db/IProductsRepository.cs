using Microsoft.AspNetCore.Http;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IProductsRepository
	{
        // получить все продукты
        Task<List<Product>> GetAllAsync();

        // получить продукт по id
        Task<Product> TryGetByIdAsync(Guid productId);

        // добавить продукт
        Task AddAsync(Product product);

        // редактировать продукт
        Task EditAsync(Product product, IFormFile[] uploadedFiles);

        // удалить продукт
        Task RemoveAsync(Guid productId);
    }
}