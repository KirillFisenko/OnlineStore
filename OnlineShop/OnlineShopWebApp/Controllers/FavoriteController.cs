using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.ComponentModel;

namespace OnlineShopWebApp.Controllers
{
	[Authorize] // доступ есть только у авторизованных пользователей

    // контроллер списка избранного
    public class FavoriteController : Controller
	{
		private readonly IProductsRepository productsRepository;
		private readonly IFavoriteRepository favoriteRepository;
		private readonly IMapper mapper;

		public FavoriteController(IProductsRepository productsRepository, IFavoriteRepository favoriteRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository;
			this.favoriteRepository = favoriteRepository;
			this.mapper = mapper;
		}

        // просмотр всего спика избранного
        public async Task<IActionResult> Index()
		{
			var products = await favoriteRepository.GetAllAsync(User.Identity.Name);
			var model = products.Select(mapper.Map<ProductViewModel>).ToList();
			return View(model);
		}

        // добавить продукт в список избранного
        public async Task<IActionResult> Addsync(Guid productId)
		{
			var product = await productsRepository.TryGetByIdAsync(productId);
			await favoriteRepository.AddAsync(User.Identity.Name, product);			
			return RedirectToAction(nameof(Index));
		}

        // удалить продукт из списка избранного
        public async Task<IActionResult> Removesync(Guid productId)
        {
            await favoriteRepository.RemoveAsync(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
        }

        // очистить список избранного
        public async Task<IActionResult> Clearsync()
        {
            await favoriteRepository.ClearAsync(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}