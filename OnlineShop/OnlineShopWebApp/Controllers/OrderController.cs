using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
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
        public IActionResult Buy(UserDeliveryInfoViewModel userViewModel)
        {
			var existingCart = cartsRepository.TryGetById(Constants.UserId);
            ViewData["cart"] = existingCart;

            if (!userViewModel.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");
            }
            if (!userViewModel.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
            }
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }

            var order = new Order
            {
                User = userViewModel.ToUser(),
                Items = existingCart.Items
            };
			var orderViewModel = order.ToOrderViewModel();

			ordersRepository.Add(order); //здесь заказ полностью добавляется

            cartsRepository.Clear(Constants.UserId); //после этого очищаются items из заказа тоже	                                                     

            return View(orderViewModel);
        }
    }
}