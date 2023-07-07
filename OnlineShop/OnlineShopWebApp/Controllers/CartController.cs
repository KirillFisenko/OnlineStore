using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		public readonly ProductRepository productRepository = new ProductRepository();
		public IActionResult Index()
		{					
			
            return View();
		}

		public IActionResult Add(int id)
		{
			return View();
		}
	}
}
