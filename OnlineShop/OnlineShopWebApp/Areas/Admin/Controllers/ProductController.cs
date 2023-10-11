using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constants.AdminRoleName)]
	[Authorize(Roles = Constants.AdminRoleName)]
	public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;
        
        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider)
        {
            this.productsRepository = productsRepository;   
            this.imagesProvider = imagesProvider;
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
                Description = product.Description                
            };

            productsRepository.Edit(prduct, productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel product)
        {
            if (productsRepository.TryGetByName(product.Name) != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            productsRepository.Add(product.ToProduct(imagesPaths));
            return RedirectToAction(nameof(Index));
        }
    }
}