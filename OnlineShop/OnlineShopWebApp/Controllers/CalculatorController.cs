using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double a, double b, string c = "+")
        {
            switch (c)
            {                
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                case "/": return $"{a} / {b} = {a / b}";
                default: return $"Необходимо правильно задать операцию.\nПриниматься могут только операции +, -, *";
            }
        }
    }
} 