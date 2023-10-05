using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constants.AdminRoleName)]
	[Authorize(Roles = Constants.AdminRoleName)]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly SignInManager<User> signInManager;
        public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager, SignInManager<User> signInManager)
        {
            this.userManager = usersManager;
            this.rolesManager = rolesManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
		{
			var users = userManager.Users.ToList();
			return View(users.Select(x => x.ToUserViewModel()).ToList());
		}

        public IActionResult Add()
        {
            return RedirectToAction("Register", "Account");
        }        

		public IActionResult Details(string name)
		{
			var user = userManager.FindByNameAsync(name).Result;
			return View(user.ToUserViewModel());
		}

		public IActionResult Remove(string name)
		{
			var user = userManager.FindByNameAsync(name).Result;
			userManager.DeleteAsync(user).Wait();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(string name)
		{
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
		}

		[HttpPost]
		public IActionResult Edit(EditUserViewModel editUserViewModel, string name)
		{
			if (ModelState.IsValid)
			{
                var user = userManager.FindByNameAsync(name).Result;
				user.PhoneNumber = editUserViewModel.Phone;
				user.UserName = editUserViewModel.UserName;
                return View(user);
			}			
			return RedirectToAction(nameof(Index));
		}

		public IActionResult ChangePassword(string name)
		{
			var changePassword = new ChangePassword()
			{
				UserName = name
			};
			return View(changePassword);
		}

		[HttpPost]
		public IActionResult ChangePassword(ChangePassword changePassword)
		{
			if (changePassword.UserName == changePassword.Password)
			{
				ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
			}

			if (ModelState.IsValid)
			{
				var user = userManager.FindByNameAsync(changePassword.UserName).Result;
				var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
				user.PasswordHash = newHashPassword;
				userManager.UpdateAsync(user).Wait();
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(ChangePassword));
		}

		public IActionResult EditRights(string userName)
		{
			var user = userManager.FindByNameAsync(userName).Result;
			var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();
            var model = new EditRightsViewModel
			{
				UserName = user.UserName,
				UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };
			return View(model);
		}

		[HttpPost]
		public IActionResult EditRights(string name, Dictionary<string, bool> userRolesViewsModel)
		{
			var userSelectedRoles = userRolesViewsModel.Select(x => x.Key);
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
			userManager.RemoveFromRolesAsync(user, userRoles).Wait();
			userManager.AddToRolesAsync(user, userRoles).Wait();            
            return RedirectToAction($"/Admin/User/Detail?name={name}");
        }
	}
}