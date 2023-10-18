using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponent
{
	public class CartViewComponent : ViewComponent
	{		
		private readonly ICartsRepository cartsRepository;
		private readonly IMapper mapper;

		public CartViewComponent(ICartsRepository cartsRepository, IMapper mapper)
		{			
			this.cartsRepository = cartsRepository;
			this.mapper = mapper;
		}
		public IViewComponentResult Invoke()
		{
			var cart = cartsRepository.TryGetById(User.Identity.Name);
			var cartViewModel = mapper.Map<CartViewModel>(cart);			
            var productCounts = cartViewModel?.Quantity ?? 0;
			return View("Cart", productCounts);
		}		
	}
}