using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository productRepository = new ProductRepository();       

        public IActionResult Index()
        {
            var products = productRepository.GetAllProducts();
            return View((object)products);
        }
    }
}