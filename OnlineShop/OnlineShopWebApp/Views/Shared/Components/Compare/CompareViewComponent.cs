using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CompareViewComponent
{
    // компонента представления счетчика товаров в списке сравнения
    public class CompareViewComponent : ViewComponent
	{		
		private readonly ICompareRepository compareRepository;

		public CompareViewComponent(ICompareRepository compareRepository)
		{			
			this.compareRepository = compareRepository;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var products = await compareRepository.GetAllAsync(User.Identity.Name);
			var productsCount = products?.Count() ?? 0;			
			return View("Compare", productsCount);
		}
	}
}