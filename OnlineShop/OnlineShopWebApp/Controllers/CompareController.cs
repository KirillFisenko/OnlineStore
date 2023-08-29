﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
	public class CompareController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICompareRepository compareRepository;

		public CompareController(IProductsRepository productRepository, ICompareRepository compareRepository)
		{
			this.productRepository = productRepository;
			this.compareRepository = compareRepository;	
		}

		public IActionResult Index()
		{
			var compareList = compareRepository.GetAllCompare();
			return View(compareList);
		}

		public IActionResult Add(int productId)
		{
			var product = productRepository.TryGetById(productId);			
            compareRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Del(int productId)
        {
            var product = productRepository.TryGetById(productId);
            compareRepository.Del(product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            compareRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}