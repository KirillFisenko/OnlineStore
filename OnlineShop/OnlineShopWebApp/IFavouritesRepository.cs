using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IFavouritesRepository
	{
		void Add(ProductViewModel product);
		public void Del(ProductViewModel product);
        public void Clear();
        public List<ProductViewModel> GetAllFavourites();
	}
}