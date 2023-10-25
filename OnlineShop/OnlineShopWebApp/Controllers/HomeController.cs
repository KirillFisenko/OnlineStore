using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly IFavoriteRepository favoriteRepository;
		private readonly ICompareRepository compareRepository;
		private readonly ICartsRepository cartsRepository;
		private readonly IMapper mapper;
       

        public HomeController(IProductsRepository productRepository, IMapper mapper, IFavoriteRepository favoriteRepository, ICompareRepository compareRepository, ICartsRepository cartsRepository)
		{
			this.productRepository = productRepository;            
            this.favoriteRepository = favoriteRepository;
            this.compareRepository = compareRepository;
            this.cartsRepository = cartsRepository;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
            var model = GetLists();
            return View(model);
        }

        public AllListsProductViewModel GetLists()
        {
            var allProducts = productRepository.GetAll();
            var favoriteProducts = favoriteRepository.GetAll(User.Identity.Name);
            var compareProducts = compareRepository.GetAll(User.Identity.Name);
            var cart = cartsRepository.TryGetById(User.Identity.Name);

            var allProductsViewModel = allProducts.Select(mapper.Map<ProductViewModel>).ToList();
            var favoriteProductsViewModel = favoriteProducts.Select(mapper.Map<ProductViewModel>).ToList();
            var compareProductsViewModel = compareProducts.Select(mapper.Map<ProductViewModel>).ToList();
            var cartViewModel = mapper.Map<CartViewModel>(cart);

            var model = new AllListsProductViewModel()
            {
                productsViewModel = allProductsViewModel,
                favoriteProductsViewModel = favoriteProductsViewModel,
                compareProductsViewModel = compareProductsViewModel,
                cartViewModel = cartViewModel
            };
            return model;
        }

        public IActionResult Category(Categories categories)
        {
            var productsCategory = productRepository.GetAll().Where(product => product.Categories == categories);
            var productsCategoryModel = productsCategory.Select(mapper.Map<ProductViewModel>).ToList();
            var model = GetLists();
            model.productsViewModel = productsCategoryModel;
            return View("Index", model);
        }        

        public IActionResult About()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if (name != null)
            {
                var products = productRepository.GetAll();
                var findProducts = products.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                var model = findProducts.Select(mapper.Map<ProductViewModel>).ToList();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}