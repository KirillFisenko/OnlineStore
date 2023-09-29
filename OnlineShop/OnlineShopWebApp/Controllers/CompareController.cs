using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
	public class CompareController : Controller
	{
		private readonly IProductsRepository productsRepository;
		private readonly ICompareRepository compareRepository;

		public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository)
		{
			this.productsRepository = productsRepository;
			this.compareRepository = compareRepository;
		}

		public IActionResult Index()
		{
			var products = compareRepository.GetAll(Constants.UserId);
			return View(products.ToProductViewModels());
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			compareRepository.Add(Constants.UserId, product);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(Guid productId)
		{
			compareRepository.Remove(Constants.UserId, productId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{
			compareRepository.Clear(Constants.UserId);
			return RedirectToAction(nameof(Index));
		}
	}
}