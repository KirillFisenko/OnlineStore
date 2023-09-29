using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {        
        private readonly IOrdersRepository ordersRepository;
        
        public OrderController(IOrdersRepository ordersRepository)
        {            
            this.ordersRepository = ordersRepository;            
        }       
       
        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders.Select(order => order.ToOrderViewModel()).ToList());
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }       
    }
}