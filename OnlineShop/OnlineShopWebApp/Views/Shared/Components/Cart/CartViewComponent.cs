using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponent
{
    // компонента представления счетчика товаров в корзине
    public class CartViewComponent : ViewComponent
	{		
		private readonly ICartsRepository cartsRepository;
		private readonly IMapper mapper;

		public CartViewComponent(ICartsRepository cartsRepository, IMapper mapper)
		{			
			this.cartsRepository = cartsRepository;
			this.mapper = mapper;
		}
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
			var cartViewModel = mapper.Map<CartViewModel>(cart);			
            var productCounts = cartViewModel?.Quantity ?? 0;
			return View("Cart", productCounts);
		}		
	}
}