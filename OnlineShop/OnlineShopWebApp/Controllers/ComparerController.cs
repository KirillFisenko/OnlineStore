using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ComparerController : Controller
    {        
        private readonly IProductsRepository productsRepository;
        private readonly IComparerRepository comparerRepository;

        public ComparerController(IProductsRepository productsRepository, IComparerRepository comparerRepository)
        {            
            this.productsRepository = productsRepository;
            this.comparerRepository = comparerRepository;
        }

        public IActionResult Index()
        {
            var cart = productsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Buy()
        {
            var cart = productsRepository.TryGetByUserId(Constants.UserId);
            comparerRepository.Add(cart);
            productsRepository.Clear(Constants.UserId);
            return View();
        }        
    }
}