using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoriteViewComponent
{
    // компонента представления счетчика товаров в списке сравнения
    public class FavoriteViewComponent : ViewComponent
	{		
		private readonly IFavoriteRepository favoriteRepository;

		public FavoriteViewComponent(IFavoriteRepository favoriteRepository)
		{			
			this.favoriteRepository = favoriteRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
            var products = await favoriteRepository.GetAllAsync(User.Identity.Name);
            var productsCount = products?.Count() ?? 0;			
			return View("Favorite", productsCount);
		}
	}
}