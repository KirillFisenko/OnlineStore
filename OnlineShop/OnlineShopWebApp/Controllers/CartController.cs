using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICartsRepository cartsRepository;
		private readonly IConstants constants;
		public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository, IConstants constants)
		{
			this.productRepository = productRepository;
			this.cartsRepository = cartsRepository;
			this.constants = constants;
		}		

		public IActionResult Index()
		{
			var cart = cartsRepository.TryGetByUserId(constants.UserId);
			return View(cart);
		}

		public IActionResult Add(int productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Add(product, constants.UserId);
			return RedirectToAction("Index");
		}
	}
}