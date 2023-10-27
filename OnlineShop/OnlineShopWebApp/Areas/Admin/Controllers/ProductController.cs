using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)] // область в проекте Admin
    [Authorize(Roles = Constants.AdminRoleName)] // доступ есть только у администратора
    
    // контроллер продуктов
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;
        private readonly IMapper mapper;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;
        }

        // отобразить все продукты
        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAllAsync();
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();			          
			return View(model);
        }

        // удалить продукт
        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            await productsRepository.RemoveAsync(productId);
            return RedirectToAction(nameof(Index));
        }        

        // редактировать продукт
        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
			var model = mapper.Map<EditProductViewModel>(product);
			return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditAsync(EditProductViewModel editProductViewModel)
        {
            if (editProductViewModel.UploadedFiles != null && !ModelState.IsValid)
            {
                return View(editProductViewModel);
            }
            if (editProductViewModel.UploadedFiles != null)
            {
                var addedImagesPaths = imagesProvider.SafeFiles(editProductViewModel.UploadedFiles, ImageFolders.Products);
                editProductViewModel.Images = addedImagesPaths.Select(path => new ImageViewModel { Url = path }).ToList();
			}
			var model = mapper.Map<Product>(editProductViewModel);
			await productsRepository.EditAsync(model, editProductViewModel.UploadedFiles);
            return RedirectToAction(nameof(Index));
        }

        // добавить продукт
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductViewModel addProductViewModel)
        {
            var products = await productsRepository.GetAllAsync();
            var findProducts = products.Where(product => product.Name.ToLower() == addProductViewModel.Name.ToLower());
            if (findProducts != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid && addProductViewModel.Images != null)
            {
                return View(addProductViewModel);
            }
            var addedImagesPaths = imagesProvider.SafeFiles(addProductViewModel.UploadedFiles, ImageFolders.Products);
			addProductViewModel.Images = addedImagesPaths.Select(path => new ImageViewModel { Url = path }).ToList();
			var model = mapper.Map<Product>(addProductViewModel);
			await productsRepository.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}