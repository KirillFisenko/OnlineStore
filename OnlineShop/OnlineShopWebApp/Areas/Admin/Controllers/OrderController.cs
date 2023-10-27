using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)] // область в проекте Admin
    [Authorize(Roles = Constants.AdminRoleName)] // доступ есть только у администратора
    public class OrderController : Controller
    {        
        private readonly IOrdersRepository ordersRepository;
		private readonly IMapper mapper;

		public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
        {            
            this.ordersRepository = ordersRepository; 
            this.mapper = mapper;
        }       
       
        // отображаем все заказы
        public async Task<IActionResult> Index()
        {
            var orders = await ordersRepository.GetAllAsync();
			var model = orders.Select(mapper.Map<OrderViewModel>).ToList();
			return  View(model);
        }

        // детали заказа
        public async Task<IActionResult> DetailsAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
			var model = mapper.Map<OrderViewModel>(order);
			return View(model);
		}

        // изменить статус заказа
        [HttpPost]
        public async Task<IActionResult> UpdateStatusAsync(Guid orderId, OrderStatusViewModel status)
        {
            await ordersRepository.UpdateStatusAsync(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }       
    }
}