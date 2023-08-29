using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAllOrders();
            return View(orders);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult DelProduct(int id)
        {
            productsRepository.Del(id);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditStatus(Guid Id)
        {
            var orders = ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == Id);            
            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult EditStatus(Guid Id, OrderStatuses Status)
        {
            var orders = ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == Id);
            currentOrder.Status = Status;
            return RedirectToAction("Orders");
        }
    }
}