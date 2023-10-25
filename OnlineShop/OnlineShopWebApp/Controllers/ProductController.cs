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

		public IActionResult Index(Guid productId)
		{
            var product = productsRepository.TryGetById(productId);
			var model = mapper.Map<ProductViewModel>(product);
			return View(model);
		}        
    }
}