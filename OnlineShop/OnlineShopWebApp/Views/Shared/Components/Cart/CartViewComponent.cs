using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponent
{
	public class CartViewComponent : ViewComponent
	{		
		private readonly ICartsRepository cartsRepository;

		public CartViewComponent(ICartsRepository cartsRepository)
		{			
			this.cartsRepository = cartsRepository;
		}
		public IViewComponentResult Invoke()
		{
			var cart = cartsRepository.TryGetById(Constants.UserId);
			var productCounts = cart?.Items?.Count() ?? 0;
			return View("Cart", productCounts);
		}
	}
}