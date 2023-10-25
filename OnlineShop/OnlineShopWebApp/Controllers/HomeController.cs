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
        private readonly IMapper mapper;
       

        public HomeController(IProductsRepository productRepository, IMapper mapper)
		{
			this.productRepository = productRepository;		
            this.mapper = mapper;            
		}

		public IActionResult Index()
		{			
			var products = productRepository.GetAll();
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();
            return View(model);
        }
        
        // получить товары по категории
        public IActionResult GetProductsByCategory(Categories categories)
        {
            var products = productRepository.GetAll().Where(product => product.Categories == categories);
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();
            return View("Index", model);
        }        

        // страница о компании
        public IActionResult About()
        {            
            return View();
        }

        // поиск товаров
        [HttpPost]
        public IActionResult SearchProduct(string name)
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