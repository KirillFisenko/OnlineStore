using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	// контроллер продукта
    public class ProductController : Controller
    {
		private readonly IProductsRepository productsRepository;
		private readonly IMapper mapper;

		public ProductController(IProductsRepository productsRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository;
			this.mapper = mapper;
		}

		// отображение продукта
		public async Task<IActionResult> Index(Guid productId)
		{
            var product = await productsRepository.TryGetByIdAsync(productId);
			var model = mapper.Map<ProductViewModel>(product);
			return View(model);
		}        
    }
}