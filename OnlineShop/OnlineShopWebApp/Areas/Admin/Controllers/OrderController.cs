using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatusesViewModel status)
        {
            ordersRepository.UpdateStatus(orderId, Mapping.ToOrderStatusesDb(status));
            return RedirectToAction(nameof(Index));
        }       
    }
}