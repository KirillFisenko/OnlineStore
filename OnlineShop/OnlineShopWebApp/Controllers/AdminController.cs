using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {        
        private readonly IProductsRepository productsRepository;
        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {            
            return View();
        }

        public IActionResult Users()
        {            
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAllProducts();
            return View(products);
        }
    }
}