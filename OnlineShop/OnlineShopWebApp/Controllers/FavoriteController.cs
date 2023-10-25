using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize] // только авторизованный пользователь может зайти
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

		public IActionResult AddOrRemove(Guid productId, string actionName = "Index", string controllerName = "Home")
		{
			var product = productsRepository.TryGetById(productId);
			var favoriteProducts = favoriteRepository.GetAll(User.Identity.Name);
			if (favoriteProducts.Contains(product))
			{
				favoriteRepository.Remove(User.Identity.Name, productId);
			}
			else
			{
				favoriteRepository.Add(User.Identity.Name, product);
			}
			return RedirectToAction(actionName, controllerName);
		}

		public IActionResult Add(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
			favoriteRepository.Add(User.Identity.Name, product);			
			return RedirectToAction(nameof(Index));
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