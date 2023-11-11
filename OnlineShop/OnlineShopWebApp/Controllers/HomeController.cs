using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    // домашний контроллер
	public class HomeController : Controller
	{
		private readonly IProductsRepository productsRepository;	
        private readonly IMapper mapper;
       

        public HomeController(IProductsRepository productsRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository;		
            this.mapper = mapper;            
		}

        // отображение всех продуктов
		public async Task<IActionResult> Index()
		{			
			var products = await productsRepository.GetAllAsync();
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();
            return View(model);
        }
        
        // получить товары по категории
        public async Task<IActionResult> GetProductsByCategoryAsync(Categories categories)
        {
            var products = await productsRepository.GetAllAsync();
            var productsFiltered = products.Where(product => product.Categories == categories);
            var model = productsFiltered.Select(mapper.Map<ProductViewModel>).ToList();
            return View("Index", model);
        }        

        // страница о компании
        public IActionResult About()
        {            
            return View();
        }

        // поиск товаров
        [HttpPost]
        public async Task<IActionResult> SearchProductAsync(string name)
        {            
            if (name != null)
			{
                var products = await productsRepository.GetAllAsync();
                var findProducts = products.Where(product => product.Name.ToLower().Contains(name.ToLower()));
				var model = findProducts.Select(mapper.Map<ProductViewModel>).ToList();
				return View(model);
			}
            return RedirectToAction(nameof(Index));
        }
    }
}