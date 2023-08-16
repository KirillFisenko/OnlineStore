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
        public IActionResult Edit(ProductEdit productEdit, int id)
        {
            var currentProduct = productRepository.TryGetById(id);
            currentProduct.Name = productEdit.Name;
            currentProduct.Cost = productEdit.Cost;
            currentProduct.Description = productEdit.Description;
            currentProduct.ImagePath = productEdit.ImagePath;
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult Add()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductEdit newProduct)
        {
            var products = productRepository.GetAllProducts();
            products.Add(new Product(newProduct.Name, newProduct.Cost, newProduct.Description, newProduct.ImagePath));
            return RedirectToAction("Products", "Admin");
        }
    }
}