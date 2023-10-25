using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// интерфейс репозитория списка сравнения
	public interface ICompareRepository
	{
		// получить список сравнения продуктов пользователя
		public List<Product> GetAll(string userId);

		// добавить в список сравнения пользователя продукт
		void Add(string userId, Product product);

		// удалить из списка сравнения пользователя продукт
		public void Remove(string userId, Guid productId);

		// очистить список сравнения пользователя
		public void Clear(string userId);		
	}
}