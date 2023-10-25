using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// интерфейс списка избранных товаров
	public interface IFavoriteRepository
	{
		// получить список избранных продуктов пользователя
		public List<Product> GetAll(string userId);

		// добавить в список избранного пользователя продукт
		void Add(string userId, Product product);

		// удалить из списка избранного пользователя продукт
		public void Remove(string userId, Guid productId);

		// очистить список избранного пользователя
		public void Clear(string userId);        
	}
}