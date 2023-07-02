using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class BasketController : Controller
	{
		private readonly BasketRepository basketRepository = new BasketRepository();
		public IActionResult Index(Product product)
		{
			var result = basketRepository.AddProductToBasket(product);
			return View(result);
		}
	}
}
