using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
	public class CompareController : Controller
	{
		private readonly IProductsRepository productRepository;
		private readonly ICompare compareRepository;

		public CompareController(IProductsRepository productRepository, ICompare compareRepository)
		{
			this.productRepository = productRepository;
			this.compareRepository = compareRepository;	
		}

		public IActionResult Index()
		{
			var compareList = compareRepository.GetAllCompare();
			return View(compareList);
		}

		public IActionResult Add(int id)
		{
			var product = productRepository.TryGetById(id);
            compareRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Del(int id)
        {
            var product = productRepository.TryGetById(id);
            compareRepository.Del(product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            compareRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}
