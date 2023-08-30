using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;
        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Orders");
        }

        //Orders
        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAllOrders();
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatuses status)
        {
            ordersRepository.UpdateOrderStatus(orderId, status);
            return RedirectToAction("Orders");
        }

        //Users
        public IActionResult Users()
        {
            return View();
        }

        //Roles
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAllRoles();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            rolesRepository.Add(role);
            return RedirectToAction("Roles");
        }

        public IActionResult RemoveRole(string name)
        {
            rolesRepository.Remove(name);
            return RedirectToAction("Roles");
        }

        //Products
        public IActionResult Products()
        {
            var products = productsRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult DelProduct(int productId)
        {
            productsRepository.Del(productId);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, int productId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productsRepository.Update(product, productId);
            return RedirectToAction("Products");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (productsRepository.TryGetByName(product.Name) != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }
    }
}