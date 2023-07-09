using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductsRepository productRepository;

		public HomeController()
		{
			productRepository = new ProductsRepository();
		}

		public IActionResult Index()
		{
			var products = productRepository.GetAllProducts();
			return View((object)products);
		}
	}
}