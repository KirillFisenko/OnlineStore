using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;       
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;            
        }       
                
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult Del(int productId)
        {
            productsRepository.Del(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, int productId)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Edit(product, productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
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
            return RedirectToAction(nameof(Index));
        }
    }
}