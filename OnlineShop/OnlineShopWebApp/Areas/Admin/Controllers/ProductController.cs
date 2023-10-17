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
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
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

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();            
            //return View(products.Select(mapper.Map<ProductViewModel>));            
            return View(products.Select(product => product.ToProductViewModel()).ToList());
        }

        public IActionResult Remove(Guid productId)
        {
            productsRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }        

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel editProductViewModel)
        {
            if (editProductViewModel.UploadedFiles != null && !ModelState.IsValid)
            {
                return View(editProductViewModel);
            }
            if (editProductViewModel.UploadedFiles != null)
            {
                var addedImagesPaths = imagesProvider.SafeFiles(editProductViewModel.UploadedFiles, ImageFolders.Products);
                editProductViewModel.ImagesPaths = addedImagesPaths;
            }           
            productsRepository.Edit(editProductViewModel.ToProduct(), editProductViewModel.UploadedFiles);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel addProductViewModel)
        {
            if (productsRepository.TryGetByName(addProductViewModel.Name) != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }
            var imagesPaths = imagesProvider.SafeFiles(addProductViewModel.UploadedFiles, ImageFolders.Products);
            productsRepository.Add(addProductViewModel.ToProduct(imagesPaths));
            return RedirectToAction(nameof(Index));
        }
    }
}