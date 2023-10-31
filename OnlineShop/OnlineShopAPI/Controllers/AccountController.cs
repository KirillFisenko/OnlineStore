using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using AutoMapper;
using OnlineShopWebApp.Helpers;

namespace OnlineShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet("Login")]
        public LoginViewModel Login(string returnUrl)
        {
            return new LoginViewModel() { ReturnUrl = returnUrl ?? "/Home" };
        }

        [HttpPost("LoginAsync")]
        public async Task<LoginViewModel> LoginAsync(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return login;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
                }
            }
            return login;
        }

        // регистрация пользователя
        [HttpGet("Register")]
        public RegisterViewModel Register(string returnUrl)
        {
            return new RegisterViewModel() { ReturnUrl = returnUrl ?? "/Home" };
        }

        [HttpPost("RegisterAsync")]
        public async Task<RegisterViewModel> RegisterAsync(RegisterViewModel register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                var addedImagePath = imagesProvider.SafeFile(register.UploadedFile, ImageFolders.Profiles);

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
                    return register;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return register;
        }

        // выход из системы пользователя
        [HttpGet("LogoutAsync")]
        public async Task LogoutAsync()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();            
        }

        // редактирование данных пользователя самим пользователем
        [HttpGet("EditAsync")]
        public async Task<EditUserByUserViewModel> EditAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = mapper.Map<EditUserByUserViewModel>(user);
            return model;
        }

        [HttpPost("EditAsync")]
        public async Task EditAsync(EditUserByUserViewModel editUserByUserViewModel)
        {
            if (editUserByUserViewModel.UploadedFile != null && !ModelState.IsValid)
            {
                
            }
            if (editUserByUserViewModel.UploadedFile != null)
            {
                var addedImagesPaths = imagesProvider.SafeFile(editUserByUserViewModel.UploadedFile, ImageFolders.Profiles);
                editUserByUserViewModel.AvatarUrl = addedImagesPaths;
            }            
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.PhoneNumber = editUserByUserViewModel.PhoneNumber;
            user.FirstName = editUserByUserViewModel.FirstName;
            user.Address = editUserByUserViewModel.Address; 
            user.AvatarUrl = editUserByUserViewModel.AvatarUrl;           
            
        }

        // просмотр заказов пользователем
        [HttpGet("OrdersAsync")]
        public async Task<List<OrderViewModel>> OrdersAsync()
        {
            var orders = await ordersRepository.GetAllAsync();
            var ordersFiltered = orders.Where(o => o.User.UserIdentityName == User.Identity.Name);
            var model = ordersFiltered.Select(mapper.Map<OrderViewModel>).ToList();
            return model;
        }

        // просмотр деталей заказов пользователя
        [HttpGet("DetailsAsync")]
        public async Task<OrderViewModel> DetailsAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
            var model = mapper.Map<OrderViewModel>(order);
            return model;
        }
    }
}