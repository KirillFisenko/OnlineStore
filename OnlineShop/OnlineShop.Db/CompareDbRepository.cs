using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// репозиторий списка сравнения товаров пользователя
	public class CompareDbRepository : ICompareRepository
	{
		private readonly DatabaseContext databaseContext;

		public CompareDbRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		// получить список сравнения продуктов пользователя
		public List<Product> GetAll(string userId)
		{
			return databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.Include(x => x.Product)
				.Select(x => x.Product)
				.ToList();
		}

		// добавить в список сравнения пользователя продукт
		public void Add(string userId, Product product)
		{
			var existingProduct = databaseContext.CompareProducts
				.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
			if (existingProduct == null)
			{
				databaseContext.CompareProducts.Add(new CompareProduct { Product = product, UserId = userId });
				databaseContext.SaveChanges();
			}
		}

		// удалить из списка сравнения пользователя продукт
		public void Remove(string userId, Guid productId)
		{
			var removingProduct = databaseContext.CompareProducts
				.FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
			
			if (removingProduct != null)
			{
				databaseContext.CompareProducts.Remove(removingProduct);
			}
			databaseContext.SaveChanges();
		}

		// очистить список сравнения пользователя
		public void Clear(string userId)
		{
			var userCompareProducts = databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.ToList();
			databaseContext.CompareProducts.RemoveRange(userCompareProducts);
			databaseContext.SaveChanges();
		}
	}
}