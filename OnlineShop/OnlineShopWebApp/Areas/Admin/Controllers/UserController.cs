using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            var model = users.Select(mapper.Map<UserViewModel>).ToList();
            return View(model);
        }

        public IActionResult Details(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var model = mapper.Map<UserViewModel>(user);
            var userRoles = userManager.GetRolesAsync(user).Result;
            ViewBag.IsAdmin = userRoles.Contains(Constants.AdminRoleName);
            return View(model);
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
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = register.UserName,
                    UserName = register.UserName,
                    PhoneNumber = register.PhoneNumber,
                    FirstName = register.FirstName,
                    Address = register.Address
                };
                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
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

        public IActionResult Remove(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            if (!userRoles.Contains(Constants.AdminRoleName))
            {
                userManager.DeleteAsync(user).Wait();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var model = mapper.Map<EditUserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel editUserViewModel, string name)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(name).Result;
                user.PhoneNumber = editUserViewModel.PhoneNumber;
                user.UserName = editUserViewModel.UserName;
                user.Address = editUserViewModel.Address;
                user.FirstName = editUserViewModel.FirstName;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View(editUserViewModel);
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePasswordViewModel()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
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

        public IActionResult EditRights(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = roleManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(role => new RoleViewModel { Name = role }).ToList(),
                AllRoles = roles.Select(role => new RoleViewModel { Name = role.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, bool> userRolesViewsModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewsModel.Select(role => role.Key);
                var user = userManager.FindByNameAsync(name).Result;
                var userRoles = userManager.GetRolesAsync(user).Result;
                userManager.RemoveFromRolesAsync(user, userRoles).Wait();
                userManager.AddToRolesAsync(user, userSelectedRoles).Wait();
                return Redirect($"/Admin/User/Details?name={name}");
            }
            return Redirect($"/Admin/User/EditRights?name={name}");
        }
    }
}