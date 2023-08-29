using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }           
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}