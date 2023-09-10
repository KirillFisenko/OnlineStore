using OnlineShop.Models;

namespace OnlineShop
{
	public interface ICompareRepository
	{
		void Add(ProductViewModel product);
		void Clear();
		void Del(ProductViewModel product);
		List<ProductViewModel> GetAllCompare();
	}
}