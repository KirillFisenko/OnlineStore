using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
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
            return View(products.ToProductViewModels());
        }

        public IActionResult Remove(Guid productId)
        {
            productsRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var productViewModel = product.ToProductViewModel();
			return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product, Guid productId)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var prduct = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

            productsRepository.Edit(prduct, productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (productsRepository.TryGetByName(product.Name) != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var prductDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

            productsRepository.Add(prductDb);
            return RedirectToAction(nameof(Index));
        }
    }
}