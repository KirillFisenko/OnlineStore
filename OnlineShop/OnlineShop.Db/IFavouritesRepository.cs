using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IFavouritesRepository
	{
		void Add(Product product);
		public void Del(Product product);
        public void Clear();
        public List<Product> GetAllFavourites();
	}
}