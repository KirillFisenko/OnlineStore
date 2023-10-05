﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

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
			var productsCount = compareRepository.GetAll(Constants.UserId)?.Count() ?? 0;			
			return View("Compare", productsCount);
		}
	}
}