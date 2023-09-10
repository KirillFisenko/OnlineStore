using OnlineShop.Models;

namespace OnlineShop
{
	public class FavouritesInMemoryRepository : IFavouritesRepository
	{
        private readonly List<ProductViewModel> favourites = new List<ProductViewModel>();

		public void Add(ProductViewModel product)
		{
			if (!favourites.Contains(product))
			{
                favourites.Add(product);
            }			
		}

        public void Del(ProductViewModel product)
        {
            favourites.Remove(product);
        }

        public void Clear()
        {
            favourites.Clear();
        }

        public List<ProductViewModel> GetAllFavourites()
		{
			return favourites;
		}
	}
}