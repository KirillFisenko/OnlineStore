using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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
            var product = productRepository.TryGetById(id);
            return View(product);
        }

        public IActionResult Del(int id)
        {
            productRepository.Del(id);
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult Edit(int id)
        {
            var product = productRepository.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Save(ProductEdit newProduct, int id)
        {
            var currentProduct = productRepository.TryGetById(id);
            currentProduct.Name = newProduct.Name;
            currentProduct.Cost = newProduct.Cost;
            currentProduct.Description = newProduct.Description;
            currentProduct.ImagePath = newProduct.ImagePath;
            return RedirectToAction("Products", "Admin");
        }
    }
}