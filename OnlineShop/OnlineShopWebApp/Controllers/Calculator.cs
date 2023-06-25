using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class Calculator : Controller
    {
        public string Index(double a, double b, string operand)
        {
            switch (operand)
            {
                case null: return $"{a} + {b} = {a + b}";
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                default: return $"Необходимо правильно задать операцию.\nПриниматься могут только операции +, -, *";
            }
        }
    }
}