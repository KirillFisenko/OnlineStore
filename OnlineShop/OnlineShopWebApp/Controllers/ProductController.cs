using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly ProductsRepository productRepository;

		public ProductController()
		{
			productRepository = new ProductsRepository();
		}

		public IActionResult Index(int id)
        {
            var result = productRepository.TryGetById(id);
            return View(result);
        }
    }
}