using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		public readonly CartsRepository CartsRepository = new CartsRepository();
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