using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)] // область в проекте Admin
    [Authorize(Roles = Constants.AdminRoleName)] // доступ есть только у администратора

    // контроллер пользователей
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;       
        private readonly ImagesProvider imagesProvider;
        private readonly IMapper mapper;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ImagesProvider imagesProvider)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
        }

        // отображение пользователей
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            var model = users.Select(mapper.Map<UserViewModel>).ToList();
            return View(model);
        }

        // детальные сведения о пользователе
        public async Task<IActionResult> DetailsAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var model = mapper.Map<UserViewModel>(user);
            var userRoles = await userManager.GetRolesAsync(user);
            ViewBag.IsAdmin = userRoles.Contains(Constants.AdminRoleName);
            return View(model);
        }


        // добавить пользователя
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RegisterViewModel register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                var addedImagePath = imagesProvider.SafeFileAsync(register.UploadedFile, ImageFolders.Profiles);

                var user = new User
                {
                    Email = register.UserName,
                    UserName = register.UserName,
                    PhoneNumber = register.PhoneNumber,
                    FirstName = register.FirstName,
                    Address = register.Address,
                    AvatarUrl = addedImagePath
                };

                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
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

        // удалить пользователя
        public async Task<IActionResult> RemoveAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var userRoles = await userManager.GetRolesAsync(user);
            if (!userRoles.Contains(Constants.AdminRoleName))
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }

        // редактировать пользователя
        public async Task<IActionResult> EditAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var model = mapper.Map<EditUserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditUserViewModel editUserViewModel, string name)
        {
            if (editUserViewModel.UploadedFile != null && !ModelState.IsValid)
            {
                return View(editUserViewModel);
            }
            if (editUserViewModel.UploadedFile != null)
            {
                var addedImagesPaths = imagesProvider.SafeFileAsync(editUserViewModel.UploadedFile, ImageFolders.Profiles);
                editUserViewModel.AvatarUrl = addedImagesPaths;
            }
            var user = await userManager.FindByNameAsync(name);
            user.PhoneNumber = editUserViewModel.PhoneNumber;
            user.UserName = editUserViewModel.UserName;
            user.Address = editUserViewModel.Address;
            user.FirstName = editUserViewModel.FirstName;
            user.AvatarUrl = editUserViewModel.AvatarUrl;
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        // смена пароля пользователя
        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePasswordViewModel()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(changePassword.UserName);
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                await userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        // смена роли пользователя
        public async Task<IActionResult> EditRightsAsync(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            var userRoles = await userManager.GetRolesAsync(user);
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
        public async Task<IActionResult> EditRightsAsync(string name, Dictionary<string, bool> userRolesViewsModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewsModel.Select(role => role.Key);
                var user = await userManager.FindByNameAsync(name);
                var userRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, userRoles);
                await userManager.AddToRolesAsync(user, userSelectedRoles);
                return Redirect($"/Admin/User/Details?name={name}");
            }
            return Redirect($"/Admin/User/EditRights?name={name}");
        }
    }
}