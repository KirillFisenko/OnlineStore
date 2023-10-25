using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public Product TryGetById(Guid productId)
        {
            return databaseContext.Products.Include(x => x.Images)
                .FirstOrDefault(product => product.Id == productId);
        }              

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit(Product product, IFormFile[] uploadedFiles)
        {
            var currentProduct = TryGetById(product.Id);
            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.Description = product.Description;
            currentProduct.Categories = product.Categories;
            
            if(uploadedFiles != null)
            {
                foreach (var image in currentProduct.Images)
                {
                    databaseContext.Images.Remove(image);
                }

                foreach (var image in product.Images)
                {
                    image.ProductId = product.Id;
                    databaseContext.Images.Add(image);
                }
            }          

            databaseContext.SaveChanges();
        }

		public void Remove(Guid productId)
		{
			var product = TryGetById(productId);
			databaseContext.Products.Remove(product);
			databaseContext.SaveChanges();
		}
	}
}