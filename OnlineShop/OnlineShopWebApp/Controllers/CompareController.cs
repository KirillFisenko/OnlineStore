using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
	public class CompareController : Controller
	{
		private readonly IProductsRepository productsRepository;
		private readonly ICompareRepository compareRepository;
		private readonly IMapper mapper;
		public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository;
			this.compareRepository = compareRepository;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			var products = compareRepository.GetAll(User.Identity.Name);
			var model = products.Select(mapper.Map<ProductViewModel>).ToList();
			return View(model);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			compareRepository.Add(User.Identity.Name, product);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(Guid productId)
		{
			compareRepository.Remove(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Clear()
		{
			compareRepository.Clear(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}