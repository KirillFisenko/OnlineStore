using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
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

		public IActionResult Index()
		{
			var cart = cartsRepository.TryGetByUserId(User.Identity.Name);
			var model = mapper.Map<CartViewModel>(cart);
			return View(model);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Add(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult DecreaseAmount(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.DecreaseAmount(product, User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{			
			cartsRepository.Clear(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}