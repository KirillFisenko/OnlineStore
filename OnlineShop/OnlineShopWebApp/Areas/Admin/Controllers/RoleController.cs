﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constants.AdminRoleName)]
	[Authorize(Roles = Constants.AdminRoleName)]
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> rolesManager;

		public RoleController(RoleManager<IdentityRole> rolesManager)
		{
			this.rolesManager = rolesManager;
		}

		public IActionResult Index()
		{
			var roles = rolesManager.Roles.ToList();
			return View(roles.Select(x => new RoleViewModel { Name = x.Name }).ToList());
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(RoleViewModel role)
		{
			var result = rolesManager.CreateAsync(new IdentityRole(role.Name)).Result;
			if(result.Succeeded)
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(role);
		}

		public IActionResult Remove(string roleName)
		{
			var role = rolesManager.FindByNameAsync(roleName).Result;
			if(role != null)
			{
				rolesManager.DeleteAsync(role).Wait();
			}			
			return RedirectToAction(nameof(Index));
		}
	}
}