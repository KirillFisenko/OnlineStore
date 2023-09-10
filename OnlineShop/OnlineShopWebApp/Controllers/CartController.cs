﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShop.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICartsRepository cartsRepository;
		
		public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
		{
			this.productRepository = productRepository;
			this.cartsRepository = cartsRepository;			
		}		

		public IActionResult Index()
		{
			var cart = cartsRepository.TryGetById(Constants.UserId);
			return View(cart);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepository.TryGetById(productId);

            var prductDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

			cartsRepository.Add(prductDb, Constants.UserId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult DecreaseAmount(Guid productId)
		{
			var product = productRepository.TryGetById(productId);

            var prductDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

			cartsRepository.DecreaseAmount(prductDb, Constants.UserId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{			
			cartsRepository.Clear(Constants.UserId);
			return RedirectToAction(nameof(Index));
		}
	}
}