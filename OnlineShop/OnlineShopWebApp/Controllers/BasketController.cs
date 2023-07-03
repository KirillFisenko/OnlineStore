using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class BasketController : Controller
	{
		private readonly BasketRepository basketRepository = new BasketRepository();

		public IActionResult Index()
		{
			var productsInBasket = basketRepository.GetAll();						
            return View(productsInBasket);
		}

		public IActionResult Add(int id)
		{
			basketRepository.AddProductToBasket(id);
			var product = ProductRepository.products.FirstOrDefault(product => product.Id == id);			
			return View(product);
		}
	}
}
