using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {        
        private readonly IOrdersRepository ordersRepository;
		private readonly IMapper mapper;

		public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
        {            
            this.ordersRepository = ordersRepository; 
            this.mapper = mapper;
        }       
       
        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
			var model = orders.Select(mapper.Map<OrderViewModel>).ToList();
			return View(model);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
			var model = mapper.Map<OrderViewModel>(order);
			return View(model);
		}

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }       
    }
}