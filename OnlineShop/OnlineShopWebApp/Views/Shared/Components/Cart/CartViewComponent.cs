using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
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
			var cart = cartsRepository.TryGetByUserId(Constants.UserId);
			var productCounts = cart?.Amount ?? 0;
			return View("Cart", productCounts);
		}
	}
}