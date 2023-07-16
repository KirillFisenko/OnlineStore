﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
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
			var cart = cartsRepository.TryGetByUserId(Constants.UserId);
			return View(cart);
		}

		public IActionResult Add(int productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Add(product, Constants.UserId);
			return RedirectToAction("Index");
		}

		public IActionResult Del(int productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Del(product, Constants.UserId);
			return RedirectToAction("Index");
		}
	}
}