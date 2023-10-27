using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// интерфейс списка избранных товаров
	public interface IFavoriteRepository
	{
		// получить список избранных продуктов пользователя
		Task<List<Product>> GetAllAsync(string userId);

        // добавить в список избранного пользователя продукт
        Task AddAsync(string userId, Product product);

        // удалить из списка избранного пользователя продукт
        Task RemoveAsync(string userId, Guid productId);

        // очистить список избранного пользователя
        Task ClearAsync(string userId);        
	}
}