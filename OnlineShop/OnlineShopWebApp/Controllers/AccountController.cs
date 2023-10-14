using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
		private readonly IOrdersRepository ordersRepository;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.ordersRepository = ordersRepository;
		}

		public IActionResult Login(string returnUrl)
		{
			return View(new Login() { ReturnUrl = returnUrl ?? "/Home" });
		}

		[HttpPost]
		public IActionResult Login(Login login)
		{
			if (ModelState.IsValid)
			{
				var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
				if (result.Succeeded)
				{
					return Redirect(login.ReturnUrl ?? "/Home");
				}
				else
				{
					ModelState.AddModelError("", "Неправильный логин или пароль");
				}
			}
			return View(login);
		}

		public IActionResult Register(string returnUrl)
		{
			return View(new Register() { ReturnUrl = returnUrl ?? "/Home" });
		}

		[HttpPost]
		public IActionResult Register(Register register)
		{
			if (register.UserName == register.Password)
			{
				ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
			}

			if (ModelState.IsValid)
			{
				User user = new User { Email = register.UserName, UserName = register.UserName, PhoneNumber = register.Phone };
				// добавляем пользователя
				var result = userManager.CreateAsync(user, register.Password).Result;
				if (result.Succeeded)
				{
					// установка куки
					signInManager.SignInAsync(user, false).Wait();
					userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
					return Redirect(register.ReturnUrl ?? "/Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			return View(register);
		}

		public IActionResult Logout()
		{
			signInManager.SignOutAsync().Wait();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		public IActionResult Data()
		{
			var user = userManager.FindByNameAsync(User.Identity.Name).Result;
			return View(user.ToEditUserByUserViewModel());
		}

		[HttpPost]
		public IActionResult Edit(EditUserByUserViewModel editUserByUserViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = userManager.FindByNameAsync(User.Identity.Name).Result;
				user.PhoneNumber = editUserByUserViewModel.Phone;				
				userManager.UpdateAsync(user).Wait();
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			return View(editUserByUserViewModel);
		}

		public IActionResult Orders()
		{
			var orders = ordersRepository.GetAll().Where(o => o.User.UserIdentityName == User.Identity.Name);			
			return View(orders.Select(o => o.ToOrderViewModel()).ToList());			
		}
		
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }
    }
}