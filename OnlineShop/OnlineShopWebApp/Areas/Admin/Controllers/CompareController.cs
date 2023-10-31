using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize] // доступ есть только у авторизованных пользователей

	// контроллер списка сравнения
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

		// просмотр всего спика сравнения
		public async Task<IActionResult> Index()
		{
			var products = await compareRepository.GetAllAsync(User.Identity.Name);
			var model = products.Select(mapper.Map<ProductViewModel>).ToList();
			return View(model);
		}

		// добавить продукт в список сравнения
		public async Task<IActionResult> AddAsync(Guid productId)
		{
			var product = await productsRepository.TryGetByIdAsync(productId);
			await compareRepository.AddAsync(User.Identity.Name, product);
			return RedirectToAction(nameof(Index));
		}

		// удалить продукт из списка сравнения
		public async Task<IActionResult> RemoveAsync(Guid productId)
		{
			await compareRepository.RemoveAsync(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
		}

		// очистить список сравнения
		public async Task<IActionResult> ClearAsync()
		{
			await compareRepository.ClearAsync(User.Identity.Name);
			return RedirectToAction(nameof(Index));
		}
	}
}