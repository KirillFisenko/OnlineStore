using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public Product TryGetById(Guid productId)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == productId);
        }

        public Product TryGetByName(string name)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Name == name);
        }

        public void Remove(Guid productId)
        {
            var product = TryGetById(productId);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit(Product product, Guid productId)
        {
            var currentProduct = TryGetById(productId);
            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.Description = product.Description;
            currentProduct.ImagePath = product.ImagePath;
            databaseContext.SaveChanges();
        }
    }
}