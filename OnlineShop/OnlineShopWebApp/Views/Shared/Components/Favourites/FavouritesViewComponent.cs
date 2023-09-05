using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavouritesViewComponent
{
	public class FavouritesViewComponent : ViewComponent
	{		
		private readonly IFavouritesRepository favouritesRepository;

		public FavouritesViewComponent(IFavouritesRepository favouritesRepository)
		{			
			this.favouritesRepository = favouritesRepository;
		}
		public IViewComponentResult Invoke()
		{
			var favourites = favouritesRepository.GetAllFavourites();
			var favouritesRepositoryCounts = favourites?.Count() ?? 0;
			return View("Favourites", favouritesRepositoryCounts);
		}
	}
}