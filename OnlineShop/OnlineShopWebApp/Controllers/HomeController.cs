using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;


namespace OnlineShopWebApp.Controllers
{    
    public class HomeController : Controller
    {        
        private readonly ProductRepository productRepository;
        public HomeController()
        {
            productRepository = new ProductRepository();
        }

        public string Index(int id)
        {
            var products = productRepository.GetAll();
            var result = "";
            if (id == 0)
            {                
                foreach(var product in products)
                {
                    result += product + "\n\n";
                }                
            }
            else
            {                
                foreach (var product in products)
                {
                    if(product.Id == id)
                    {
                        result += product + "\n" + product.Description; break;
                    }                    
                }                
            }
            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}