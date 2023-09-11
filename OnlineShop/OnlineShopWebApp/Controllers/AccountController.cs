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
            usersRepository.Add(new User(register.UserName, register.Password, register.FirstName, register.LastName, register.Phone));
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}