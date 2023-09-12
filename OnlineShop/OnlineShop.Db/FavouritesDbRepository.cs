using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class FavouritesDbRepository : IFavouritesRepository
	{
        private readonly DatabaseContext databaseContext;

        public FavouritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
		{
			if (!databaseContext.Favourites.Contains(product))
			{
                databaseContext.Favourites.Add(product);
            }
            databaseContext.SaveChanges();
        }

        public void Del(Product product)
        {
            databaseContext.Favourites.Remove(product);
            databaseContext.SaveChanges();
        }

        public void Clear()
        {
            foreach(var item in databaseContext.Favourites)
            {
                databaseContext.Favourites.Remove(item);
            }            
            databaseContext.SaveChanges();
        }

        public List<Product> GetAllFavourites()
		{
			return databaseContext.Favourites.ToList();
		}
	}
}