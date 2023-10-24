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
	[Authorize]
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

		public IActionResult Index()
		{
			var products = favoriteRepository.GetAll(User.Identity.Name);
			var model = products.Select(mapper.Map<ProductViewModel>).ToList();
			return View(model);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			favoriteRepository.Add(User.Identity.Name, product);			
			return RedirectToAction(nameof(Index), "Home");
		}

        public IActionResult Remove(Guid productId)
        {            
			favoriteRepository.Remove(User.Identity.Name, productId);
			return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favoriteRepository.Clear(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}