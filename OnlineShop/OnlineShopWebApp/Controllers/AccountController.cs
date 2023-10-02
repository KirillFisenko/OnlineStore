using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Data;

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
            var userAccount = usersRepository.TryGetByName(user.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем не найден. Проверьте имя или зарегистрируйтесь.");
            }
            if (userAccount != null && userAccount.Password != user.Password)
            {
                ModelState.AddModelError("", "Не верный пароль");
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            var userAccount = usersRepository.TryGetByName(register.UserName);
            if (userAccount != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже есть.");
            }
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }
            if (!register.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
            }
            if (!register.FirstName.All(char.IsLetter))
            {
                ModelState.AddModelError("", "Имя должно содержать только буквы");
            }
            if (!register.LastName.All(char.IsLetter))
            {
                ModelState.AddModelError("", "Фамилия должна содержать только буквы");
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }
			var newUser = new User
			{
				Id = Guid.NewGuid(),
				Name = register.UserName,
				Password = register.Password,
				FirstName = register.FirstName,
				LastName = register.LastName,
				Phone = register.Phone,
				Role = new Role { Name = "User" }
			};
			usersRepository.Add(newUser);
			return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}