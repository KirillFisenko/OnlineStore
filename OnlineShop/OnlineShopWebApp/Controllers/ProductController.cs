using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductsRepository productRepository;

		public ProductController(IProductsRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public IActionResult Index(int id)
        {
            var result = productRepository.TryGetById(id);
            return View(result);
        }

        public IActionResult Del(int id)
        {
            productRepository.Del(id);
            return RedirectToAction("Products", "Admin");
        }
    }
}