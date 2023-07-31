﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(User user)
        {
            return Redirect("~/Home/Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(User user)
        {
            return Redirect("~/Home/Index");
        }
    }
}