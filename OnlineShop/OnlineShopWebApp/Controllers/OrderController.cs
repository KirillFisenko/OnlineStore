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
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
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