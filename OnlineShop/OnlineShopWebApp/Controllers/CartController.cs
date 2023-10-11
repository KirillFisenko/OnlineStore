using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
	public class CartController : Controller
	{		
		private readonly IProductsRepository productRepository;
		private readonly ICartsRepository cartsRepository;
		
		public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
		{
			this.productRepository = productRepository;
			this.cartsRepository = cartsRepository;			
		}		

		public IActionResult Index()
		{
			var cart = cartsRepository.TryGetById(User.Identity.Name);
			return View(cart.ToCartViewModel());
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Add(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult DecreaseAmount(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.DecreaseAmount(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{			
			cartsRepository.Clear(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}