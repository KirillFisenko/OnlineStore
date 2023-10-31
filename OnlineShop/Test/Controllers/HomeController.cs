using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public HomeController(IProductsRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        // отображение всех продуктов
        [HttpGet("Index")]
        public async Task<List<ProductViewModel>> Index()
        {
            var products = await productsRepository.GetAllAsync();
            var model = products.Select(mapper.Map<ProductViewModel>).ToList();
            return model;
        }
    }
}
