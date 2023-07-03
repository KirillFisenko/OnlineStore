﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductRepository productRepository = new ProductRepository();

        public IActionResult Index(int id)
        {
            var result = productRepository.GetById(id);
            return View((object)result);
        }
    }
}