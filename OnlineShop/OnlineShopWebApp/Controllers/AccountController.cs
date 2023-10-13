﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
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
	}
}