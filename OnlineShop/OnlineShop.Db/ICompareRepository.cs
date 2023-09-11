using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface ICompareRepository
	{
		void Add(Product product);
		void Clear();
		void Del(Product product);
		List<Product> GetAllCompare();
	}
}