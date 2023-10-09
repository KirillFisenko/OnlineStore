using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constants.AdminRoleName)]
	[Authorize(Roles = Constants.AdminRoleName)]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
		{
			var users = userManager.Users.ToList();
			return View(users.Select(x => x.ToUserViewModel()).ToList());
		}

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }			
            if (ModelState.IsValid)
            {
                User user = new User { Email = register.UserName, UserName = register.UserName, Name = register.UserName, PhoneNumber = register.Phone, Phone = register.Phone };
                                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    TryAssignUserRole(user);
					return RedirectToAction(nameof(Index));
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
        public void TryAssignUserRole(User user)
        {
            try
            {
                userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                // log
            }
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
            return View(user.ToEditUserViewModel());
		}

		[HttpPost]
		public IActionResult Edit(EditUserViewModel editUserViewModel, string name)
		{
			if (ModelState.IsValid)
			{
                var user = userManager.FindByNameAsync(name).Result;
				user.Phone = editUserViewModel.Phone;
                user.PhoneNumber = editUserViewModel.Phone;
                user.UserName = editUserViewModel.UserName;
                user.Name = editUserViewModel.UserName;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View(editUserViewModel);
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

		//добавить защиту от не выбора ролей
		public IActionResult EditRights(string name)
		{
			var user = userManager.FindByNameAsync(name).Result;
			var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = roleManager.Roles.ToList();
            var model = new EditRightsViewModel
			{
				UserName = user.UserName,
				UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };
			return View(model);
		}

		[HttpPost]
		public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewsModel)
		{
			var userSelectedRoles = userRolesViewsModel.Select(x => x.Key);
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
			userManager.RemoveFromRolesAsync(user, userRoles).Wait();
			userManager.AddToRolesAsync(user, userSelectedRoles).Wait();            
            return Redirect($"/Admin/User/Details?name={name}");
        }
	}
}