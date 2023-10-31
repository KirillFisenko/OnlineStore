﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using AutoMapper;
using OnlineShopWebApp.Helpers;
using Microsoft.Win32;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    // контроллер аккаунтов
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;               
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;
        private readonly EmailService emailService;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository, IMapper mapper, ImagesProvider imagesProvider, EmailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;            
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;
            this.emailService = emailService;
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

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callBackUrl = Url.Action("ConfirmEmail", "Account",
                        new
                        {
                            userId = user.Id,
                            code = code
                        },
                        protocol: HttpContext.Request.Scheme);
                    await emailService.SendEmailAsync(register.UserName, "Подтвердите свой профиль",
                        $"Подтвердите регистрацию, перейдя <a href='{callBackUrl}'>по ссылке</a>");
                    //return Redirect(register.ReturnUrl ?? "/Home");
                    return View("ConfirmEmail");
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

        // забыли пароль
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callBackUrl = Url.Action("ResetPassword", "Account", new
                {
                    userId = user.Id,
                    Code = code
                }, protocol: HttpContext.Request.Scheme);
                await emailService.SendEmailAsync(model.Email, "Сброс пароля",
                         $"Для сброса пароля, перейдите <a href='{callBackUrl}'>по ссылке</a>");
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        // сброс пароля
        public IActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model); 
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("ResetPasswordConfirmation");
            }
            var confirmPasswords = await userManager.CheckPasswordAsync(user, model.Password);
            if (confirmPasswords)
            {
                ModelState.AddModelError(string.Empty, "Старый пароль не должен совпадать с новым");
                return View(model);
            }
            var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
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
                var addedImagesPaths = imagesProvider.SafeFile(editUserByUserViewModel.UploadedFile, ImageFolders.Profiles);
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