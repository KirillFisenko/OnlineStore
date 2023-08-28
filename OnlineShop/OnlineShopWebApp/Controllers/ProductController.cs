using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductsRepository productsRepository;

		public ProductController(IProductsRepository productsRepository)
		{
			this.productsRepository = productsRepository;
		}

		public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product);
        }        
    }
}