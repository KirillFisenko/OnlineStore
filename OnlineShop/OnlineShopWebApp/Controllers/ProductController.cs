using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductsRepository productsRepository;

		public ProductController(IProductsRepository productsRepository)
		{
			this.productsRepository = productsRepository;
		}

		public IActionResult Index(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }        
    }
}