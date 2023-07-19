using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Buy()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(cart);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }        
    }
}