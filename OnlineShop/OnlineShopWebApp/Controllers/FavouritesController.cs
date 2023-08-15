using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
	public class FavouritesController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly IFavourites favouritesRepository;

		public FavouritesController(IProductsRepository productRepository, IFavourites favouritesRepository)
		{
			this.productRepository = productRepository;
			this.favouritesRepository = favouritesRepository;	
		}

		public IActionResult Index()
		{
			var compareList = favouritesRepository.GetAllFavourites();
			return View(compareList);
		}

		public IActionResult Add(int id)
		{
			var product = productRepository.TryGetById(id);
            favouritesRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Del(int id)
        {
            var product = productRepository.TryGetById(id);
            favouritesRepository.Del(product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            favouritesRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}