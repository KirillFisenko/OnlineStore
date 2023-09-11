using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface ICompareRepository
	{
		void Add(ProductViewModel product);
		void Clear();
		void Del(ProductViewModel product);
		List<ProductViewModel> GetAllCompare();
	}
}