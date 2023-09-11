using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class CompareInMemoryRepository : ICompareRepository
	{
        private readonly List<ProductViewModel> compare = new List<ProductViewModel>();

		public void Add(ProductViewModel product)
		{
			if (!compare.Contains(product))
			{
                compare.Add(product);
            }			
		}

		public void Del(ProductViewModel product)
		{
			compare.Remove(product);
		}

		public void Clear()
		{
			compare.Clear();
		}

		public List<ProductViewModel> GetAllCompare()
		{
			return compare;
		}
	}
}