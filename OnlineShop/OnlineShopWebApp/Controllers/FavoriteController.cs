using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
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
			var products = favoriteRepository.GetAll(Constants.UserId);
			return View(products.ToProductViewModels());
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			favoriteRepository.Add(Constants.UserId, product);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {            
			favoriteRepository.Remove(Constants.UserId, productId);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favoriteRepository.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}