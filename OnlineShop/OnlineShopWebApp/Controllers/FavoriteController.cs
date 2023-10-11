using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
	public class FavoriteController : Controller
	{
		private readonly IProductsRepository productsRepository;
		private readonly IFavoriteRepository favoriteRepository;

		public FavoriteController(IProductsRepository productsRepository, IFavoriteRepository favoriteRepository)
		{
			this.productsRepository = productsRepository;
			this.favoriteRepository = favoriteRepository;	
		}

		public IActionResult Index()
		{
			var products = favoriteRepository.GetAll(User.Identity.Name);
			return View(products.ToProductViewModels());
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			favoriteRepository.Add(User.Identity.Name, product);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {            
			favoriteRepository.Remove(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favoriteRepository.Clear(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}