using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class CompareInMemoryRepository : ICompareRepository
	{
		public List<Product> compare = new List<Product>();

		public void Add(Product product)
		{
			if (!compare.Contains(product))
			{
                compare.Add(product);
            }			
		}

		public void Del(Product product)
		{
			compare.Remove(product);
		}

		public void Clear()
		{
			compare.Clear();
		}

		public List<Product> GetAllCompare()
		{
			return compare;
		}
	}
}