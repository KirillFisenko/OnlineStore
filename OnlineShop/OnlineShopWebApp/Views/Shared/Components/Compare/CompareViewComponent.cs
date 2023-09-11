using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CompareViewComponent
{
	public class CompareViewComponent : ViewComponent
	{		
		private readonly ICompareRepository compareRepository;

		public CompareViewComponent(ICompareRepository compareRepository)
		{			
			this.compareRepository = compareRepository;
		}
		public IViewComponentResult Invoke()
		{
			var compare = compareRepository.GetAllCompare();
			var compareRepositoryRepositoryCounts = compare?.Count() ?? 0;
			return View("Compare", compareRepositoryRepositoryCounts);
		}
	}
}