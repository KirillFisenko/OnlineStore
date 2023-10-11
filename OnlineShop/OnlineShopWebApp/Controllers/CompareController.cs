using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
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
			var products = compareRepository.GetAll(User.Identity.Name);
			return View(products.ToProductViewModels());
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			compareRepository.Add(User.Identity.Name, product);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(Guid productId)
		{
			compareRepository.Remove(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{
			compareRepository.Clear(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}