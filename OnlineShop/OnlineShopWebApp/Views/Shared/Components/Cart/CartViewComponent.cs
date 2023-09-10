using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

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
			var cartViewModel = Mapping.ToCartViewModel(cart);
            var productCounts = cartViewModel?.Quantity ?? 0;
			return View("Cart", productCounts);
		}		
	}
}