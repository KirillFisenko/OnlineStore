using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoriteViewComponent
{
	public class FavoriteViewComponent : ViewComponent
	{		
		private readonly IFavoriteRepository favoriteRepository;

		public FavoriteViewComponent(IFavoriteRepository favoriteRepository)
		{			
			this.favoriteRepository = favoriteRepository;
		}
		public IViewComponentResult Invoke()
		{
			var productsCount = favoriteRepository.GetAll(User.Identity.Name)?.Count() ?? 0;			
			return View("Favorite", productsCount);
		}
	}
}