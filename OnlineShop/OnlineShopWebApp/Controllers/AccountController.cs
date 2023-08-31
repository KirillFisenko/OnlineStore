using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository usersRepository;        

        public AccountController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;            
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {            
            if (usersRepository.TryGetByName(user.UserName) == null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем не найден. Проверьте имя или зарегистрируйтесь.");
            }
            else
            {
                if (usersRepository.TryGetByName(user.UserName).Password != user.Password)
                {
                    ModelState.AddModelError("", "Не верный пароль");
                }
            }
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
            var newUser = new User(register.UserName, register.Password);
            usersRepository.Add(newUser);
            return RedirectToAction("Index", "Home");
        }
    }
}