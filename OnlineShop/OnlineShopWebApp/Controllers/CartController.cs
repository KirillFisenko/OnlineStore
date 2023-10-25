using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
			var cart = cartsRepository.TryGetById(User.Identity.Name);
			var model = mapper.Map<CartViewModel>(cart);
			return View(model);
		}

		public IActionResult AddOrRemove(Guid productId)
		{
			var product = productRepository.TryGetById(productId);
			var cart = cartsRepository.TryGetById(User.Identity.Name);
			var productInCart = cart?.Items?
				.FirstOrDefault(item => item.Product.Id == product.Id);
			if (productInCart != null)
			{
				cartsRepository.Remove(product, User.Identity.Name);
			}
			else
			{
				cartsRepository.Add(product, User.Identity.Name);
			}
			return RedirectToAction(nameof(Index), "Home");
		}

		public IActionResult Add(Guid productId, string url = "Cart")
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.Add(product, User.Identity.Name);
			return RedirectToAction(nameof(Index), url);
		}

		public IActionResult DecreaseAmount(Guid productId, string url = "Cart")
		{
			var product = productRepository.TryGetById(productId);
			cartsRepository.DecreaseAmount(product, User.Identity.Name);
			return RedirectToAction(nameof(Index), url);
		}

		public IActionResult Clear()
		{
			cartsRepository.Clear(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}