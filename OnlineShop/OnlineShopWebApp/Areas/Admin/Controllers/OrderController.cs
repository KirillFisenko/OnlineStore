using Microsoft.AspNetCore.Mvc;
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
        public IActionResult UpdateStatus(Guid orderId, OrderStatuses status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }       
    }
}