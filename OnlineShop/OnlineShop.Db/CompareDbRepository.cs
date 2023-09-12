using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp
{
	public class CompareDbRepository : ICompareRepository
	{
        private readonly DatabaseContext databaseContext;

        public CompareDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
		{
			if (!databaseContext.Compare.Contains(product))
			{
                databaseContext.Compare.Add(product);
            }
            databaseContext.SaveChanges();
        }

		public void Del(Product product)
		{
            databaseContext.Compare.Remove(product);
            databaseContext.SaveChanges();
        }

		public void Clear()
		{
            foreach (var item in databaseContext.Compare)
            {
                databaseContext.Compare.Remove(item);
            }            
            databaseContext.SaveChanges();
        }

		public List<Product> GetAllCompare()
		{
			return databaseContext.Compare.ToList();
		}
	}
}