using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IFavouritesRepository
	{
		void Add(Product product);
		public void Del(Product product);
        public void Clear();
        public List<Product> GetAllFavourites();
	}
}