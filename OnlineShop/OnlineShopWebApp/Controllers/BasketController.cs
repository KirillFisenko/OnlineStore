using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class BasketController : Controller
	{
        private readonly UserRepository userRepository = new UserRepository();
        public IActionResult Index()
		{
			var productsInBasket = userRepository.GetUserShoppingList();						
            return View(productsInBasket);
		}

		public IActionResult Add(int id)
		{
            userRepository.AddProductToUserList(id);
			var product = ProductRepository.products.FirstOrDefault(product => product.Id == id);			
			return View(product);
		}
	}
}
