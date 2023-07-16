using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductsRepository productRepository;

		public HomeController(ProductsRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public IActionResult Index()
		{
			var products = productRepository.GetAllProducts();
			return View((object)products);
		}
	}
}