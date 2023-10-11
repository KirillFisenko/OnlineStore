using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
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
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel userViewModel)
        {
			if (!ModelState.IsValid)
			{
				return View(nameof(Index), userViewModel);
			}
			var existingCart = cartsRepository.TryGetById(User.Identity.Name);           

            var order = new Order
            {
                User = userViewModel.ToUser(),
                Items = existingCart.Items
            };			
			ordersRepository.Add(order);
            cartsRepository.Clear(User.Identity.Name);
            return View(order.ToOrderViewModel());
        }
    }
}