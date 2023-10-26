using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// интерфейс репозитория списка сравнения
	public interface ICompareRepository
	{
        // получить список сравнения продуктов пользователя
        Task<List<Product>> GetAllAsync(string userId);

        // добавить в список сравнения пользователя продукт
        Task AddAsync(string userId, Product product);

        // удалить из списка сравнения пользователя продукт
        Task RemoveAsync(string userId, Guid productId);

        // очистить список сравнения пользователя
        Task ClearAsync(string userId);		
	}
}