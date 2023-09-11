using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
	public class FavouritesController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly IFavouritesRepository favouritesRepository;

		public FavouritesController(IProductsRepository productRepository, IFavouritesRepository favouritesRepository)
		{
			this.productRepository = productRepository;
			this.favouritesRepository = favouritesRepository;	
		}

		public IActionResult Index()
		{
			var favouritesList = favouritesRepository.GetAllFavourites();
			return View(favouritesList);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
            //favouritesRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Del(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            //favouritesRepository.Del(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favouritesRepository.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}