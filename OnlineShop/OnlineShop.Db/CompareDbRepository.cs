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
		public async Task<List<Product>> GetAllAsync(string userId)
		{
			return await databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.Include(x => x.Product)
				.Select(x => x.Product)
				.ToListAsync();
		}

		// добавить в список сравнения пользователя продукт
		public async Task AddAsync(string userId, Product product)
		{
			var existingProduct = await databaseContext.CompareProducts
				.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == product.Id);
			if (existingProduct == null)
			{
				await databaseContext.CompareProducts.AddAsync(new CompareProduct { Product = product, UserId = userId });
                await databaseContext.SaveChangesAsync();
			}
		}

		// удалить из списка сравнения пользователя продукт
		public async Task RemoveAsync(string userId, Guid productId)
		{
			var removingProduct = await databaseContext.CompareProducts
				.FirstOrDefaultAsync(u => u.UserId == userId && u.Product.Id == productId);
			
			if (removingProduct != null)
			{
				databaseContext.CompareProducts.Remove(removingProduct);
			}
            await databaseContext.SaveChangesAsync();
		}

		// очистить список сравнения пользователя
		public async Task ClearAsync(string userId)
		{
			var userCompareProducts = await databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.ToListAsync();
			databaseContext.CompareProducts.RemoveRange(userCompareProducts);
            await databaseContext.SaveChangesAsync();
		}
	}
}