using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {        
        private readonly ICartsRepository cartsRepository;

        public OrderController(ICartsRepository cartsRepository)
        {            
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult MakeOrder()
        {
            cartsRepository.Clear(Constants.UserId);
            return View("~/Views/Order/Success.cshtml");
        }
    }
}