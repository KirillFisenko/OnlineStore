using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            ViewData["cart"] = cart;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
			var existingCart = cartsRepository.TryGetById(Constants.UserId);
			ViewData["cart"] = existingCart;

			if (!user.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");               
            }
            if (!user.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");				
			}
            if (!ModelState.IsValid)
            {
				return View(nameof(Index));
			}

            
            var order = new Order
            {
                User = user,
                Items = existingCart.Items
            };
            ordersRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View(order);
        }
    }
}