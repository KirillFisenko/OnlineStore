using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductsRepository productRepository;

		public HomeController(IProductsRepository productRepository)
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