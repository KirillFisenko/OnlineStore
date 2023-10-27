using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using AutoMapper;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    // контроллер аккаунтов
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;               
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository, IMapper mapper, ImagesProvider imagesProvider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;            
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;
        }

        // авторизация пользователя
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
                }
            }
            return View(login);
        }

        // регистрация пользователя
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel register)
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

                // добавляем пользователя
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
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

        // выход из системы пользователя
        public async Task<IActionResult> LogoutAsync()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // редактирование данных пользователя самим пользователем
        public async Task<IActionResult> EditAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = mapper.Map<EditUserByUserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditUserByUserViewModel editUserByUserViewModel)
        {
            if (editUserByUserViewModel.UploadedFile != null && !ModelState.IsValid)
            {
                return View(editUserByUserViewModel);
            }
            if (editUserByUserViewModel.UploadedFile != null)
            {
                var addedImagesPaths = imagesProvider.SafeFileAsync(editUserByUserViewModel.UploadedFile, ImageFolders.Profiles);
                editUserByUserViewModel.AvatarUrl = addedImagesPaths;
            }            
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.PhoneNumber = editUserByUserViewModel.PhoneNumber;
            user.FirstName = editUserByUserViewModel.FirstName;
            user.Address = editUserByUserViewModel.Address; 
            user.AvatarUrl = editUserByUserViewModel.AvatarUrl;
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // просмотр заказов пользователем
        public async Task<IActionResult> OrdersAsync()
        {
            var orders = await ordersRepository.GetAllAsync();
            var ordersFiltered = orders.Where(o => o.User.UserIdentityName == User.Identity.Name);
            var model = ordersFiltered.Select(mapper.Map<OrderViewModel>).ToList();
            return View(model);
        }

        // просмотр деталей заказов пользователя
        public async Task<IActionResult> DetailsAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
            var model = mapper.Map<OrderViewModel>(order);
            return View(model);
        }
    }
}