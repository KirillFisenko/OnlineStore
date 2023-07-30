using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            var orders = "Заказы";
            return View();
        }

        public IActionResult GetUsers()
        {
            return View("Пользователи");
        }

        public IActionResult GetRoles()
        {
            return View("Роли");
        }

        public IActionResult GetProducts()
        {
            return View("Продукты");
        }

    }
}