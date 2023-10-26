using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// репозиторий списка избранных товаров пользователя
	public class FavoriteDbRepository : IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

		// получить список избранных продуктов пользователя
		public async Task<List<Product>> GetAllAsync(string userId)
		{
			return await databaseContext.FavoriteProducts
				.Where(u => u.UserId == userId)
				.Include(x => x.Product)
				.Select(x => x.Product)
				.ToListAsync();
		}

		// добавить в список избранного пользователя продукт
		public async Task AddAsync(string userId, Product product)
        {
            var existingProduct = await databaseContext.FavoriteProducts
				.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                await databaseContext.FavoriteProducts.AddAsync(new FavoriteProduct { Product = product, UserId = userId });
                await databaseContext.SaveChangesAsync();
            }
        }

		// удалить из списка избранного пользователя продукт
		public async Task RemoveAsync(string userId, Guid productId)
        {
            var removingProduct = await databaseContext.FavoriteProducts
				.FirstOrDefaultAsync(u => u.UserId == userId && u.Product.Id == productId);
			
            if (removingProduct != null)
            {
				databaseContext.FavoriteProducts.Remove(removingProduct);
			}
            await databaseContext.SaveChangesAsync();
        }

		// очистить список избранного пользователя
		public async Task ClearAsync(string userId)
        {
            var userFavoriteProducts = await databaseContext.FavoriteProducts
				.Where(u => u.UserId == userId)
                .ToListAsync();
            databaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            await databaseContext.SaveChangesAsync();
        }       
    }
}