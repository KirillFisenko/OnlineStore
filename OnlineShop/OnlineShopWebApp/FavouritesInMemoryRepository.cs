using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class FavouritesInMemoryRepository : IFavouritesRepository
	{
        private readonly List<Product> favourites = new List<Product>();

		public void Add(Product product)
		{
			if (!favourites.Contains(product))
			{
                favourites.Add(product);
            }			
		}

        public void Del(Product product)
        {
            favourites.Remove(product);
        }

        public void Clear()
        {
            favourites.Clear();
        }

        public List<Product> GetAllFavourites()
		{
			return favourites;
		}
	}
}