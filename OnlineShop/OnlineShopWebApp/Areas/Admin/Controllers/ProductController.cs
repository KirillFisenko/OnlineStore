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
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();			          
			return View(model);
        }

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(AddProductViewModel addProductViewModel)
		{
			if (productsRepository.GetAll().FirstOrDefault(product => product.Name == addProductViewModel.Name) != null)
			{
				ModelState.AddModelError(string.Empty, "Продукт с таким именем уже сущствует");
			}
			if (!ModelState.IsValid && addProductViewModel.Images != null)
			{
				return View(addProductViewModel);
			}
			var addedImagesPaths = imagesProvider.SafeFiles(addProductViewModel.UploadedFiles, ImageFolders.Products);
			addProductViewModel.Images = addedImagesPaths.Select(path => new ImageViewModel { Url = path }).ToList();
			var model = mapper.Map<Product>(addProductViewModel);
			productsRepository.Add(model);
			return RedirectToAction(nameof(Index));
		}		      

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
			var model = mapper.Map<EditProductViewModel>(product);
			return View(model);
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
                editProductViewModel.Images = addedImagesPaths.Select(path => new ImageViewModel { Url = path }).ToList();
			}
			var model = mapper.Map<Product>(editProductViewModel);
			productsRepository.Edit(model, editProductViewModel.UploadedFiles);
            return RedirectToAction(nameof(Index));
        }

		public IActionResult Remove(Guid productId)
		{
			productsRepository.Remove(productId);
			return RedirectToAction(nameof(Index));
		}
	}
}