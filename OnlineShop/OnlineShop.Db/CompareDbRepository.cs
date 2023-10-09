using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class CompareDbRepository : ICompareRepository
	{
		private readonly DatabaseContext databaseContext;

		public CompareDbRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

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

		public void Remove(string userId, Guid productId)
		{
			var removingCompare = databaseContext.CompareProducts
				.FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
			databaseContext.CompareProducts.Remove(removingCompare);
			databaseContext.SaveChanges();
		}
		
		public void Clear(string userId)
		{
			var userCompareProducts = databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.ToList();
			databaseContext.CompareProducts.RemoveRange(userCompareProducts);
			databaseContext.SaveChanges();
		}

		public List<Product> GetAll(string userId)
		{
			return databaseContext.CompareProducts
				.Where(u => u.UserId == userId)
				.Include(x => x.Product)
				.Select(x => x.Product)
				.ToList();
		}
	}
}