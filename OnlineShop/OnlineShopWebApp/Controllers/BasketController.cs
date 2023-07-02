using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class BasketController : Controller
	{
		private readonly BasketRepository basketRepository = new BasketRepository();
		public IActionResult Index()
		{
			var products = basketRepository.GetAll();
			return View((object)products);
		}

		public void Add(Product product)
		{
			basketRepository.AddProductToBasket(product);
		}
	}
}
