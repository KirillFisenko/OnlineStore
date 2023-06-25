﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class Calculator : Controller
    {
        public string Index(double a, double b)
        {
            return $"{a} + {b} = {a + b}";
        }
    }
}
