using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopAPI.Controllers
{
	[Authorize] // доступ есть только у авторизованных пользователей
    [ApiController]
    [Route("[controller]")]

    // контроллер корзины
    public class CartController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICartsRepository cartsRepository;
		private readonly IMapper mapper;

		public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository, IMapper mapper)
		{
			this.productRepository = productRepository;
			this.cartsRepository = cartsRepository;
			this.mapper = mapper;
		}

		// просмотр всей корзины пользователя
		public async Task<IActionResult> Index()
		{
			var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
			var model = mapper.Map<CartViewModel>(cart);
			return View(model);
		}		

		// добавить продукт в корзину
		public async Task<IActionResult> AddAsync(Guid productId)
		{
			var product = await productRepository.TryGetByIdAsync(productId);
			await cartsRepository.AddAsync(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		// уменьшить количество товараов в корзине на 1
		public async Task<IActionResult> DecreaseAmountAsync(Guid productId)
		{
			var product = await productRepository.TryGetByIdAsync(productId);
			await cartsRepository.DecreaseAmountAsync(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		// очистить корзину пользователя
		public async Task<IActionResult> ClearAsync()
		{
			await cartsRepository.ClearAsync(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}