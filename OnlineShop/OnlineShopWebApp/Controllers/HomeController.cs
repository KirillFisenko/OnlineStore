using Microsoft.AspNetCore.Mvc;

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
			return View(products);
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