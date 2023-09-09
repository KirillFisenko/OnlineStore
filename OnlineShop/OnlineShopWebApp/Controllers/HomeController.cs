using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp;
using OnlineShopWebApp.Db;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductsRepository productRepository;		

		public HomeController(IProductsRepository productRepository)
		{
			this.productRepository = productRepository;			
		}

		public IActionResult Index()
		{			
			var products = productRepository.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }
			return View(productsViewModels);
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
                return View(findProducts);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}