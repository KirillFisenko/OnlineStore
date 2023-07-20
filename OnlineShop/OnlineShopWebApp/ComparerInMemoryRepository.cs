using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ComparerInMemoryRepository : IComparerRepository
	{
        public List<Product> comparer = new List<Product>();

        public void Add(Product product)
        {
            comparer.Add(product);
        }
    }
}