using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
	public class CompareController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICompareRepository compareRepository;

		public CompareController(IProductsRepository productRepository, ICompareRepository compareRepository)
		{
			this.productRepository = productRepository;
			this.compareRepository = compareRepository;	
		}

		public IActionResult Index()
		{
			var compareList = compareRepository.GetAllCompare();
			return View(compareList);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			compareRepository.Add(product);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Del(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
			compareRepository.Del(product);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            compareRepository.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}