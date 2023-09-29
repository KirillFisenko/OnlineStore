using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IFavoriteRepository
	{
		void Add(string userId, Product product);
		public void Remove(string userId, Guid productId);
        public void Clear(string userId);
        public List<Product> GetAll(string userId);
	}
}