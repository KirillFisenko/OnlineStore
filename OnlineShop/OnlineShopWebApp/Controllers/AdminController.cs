using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Data;
using System.Xml.Linq;

namespace OnlineShopWebApp.Controllers
{
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
            var roles = rolesRepository.GetAllRoles();
            return View(roles);
        }

        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoles(Roles role)
        {
            var roles = rolesRepository.GetAllRoles();
            if (roles.FirstOrDefault(r => r.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            rolesRepository.Add(role);
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public IActionResult DelRoles(string Name)
        {
            var roles = rolesRepository.GetAllRoles();
            var currentRole = roles.FirstOrDefault(role => role.Name == Name);
            rolesRepository.Del(currentRole);
            return RedirectToAction("Roles");
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
        public IActionResult EditProduct(Product product)
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