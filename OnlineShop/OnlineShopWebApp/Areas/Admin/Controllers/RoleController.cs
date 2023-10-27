using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)] // область в проекте Admin
    [Authorize(Roles = Constants.AdminRoleName)] // доступ есть только у администратора

    // контроллер ролей
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolesManager;

        public RoleController(RoleManager<IdentityRole> rolesManager)
        {
            this.rolesManager = rolesManager;
        }

        // отображение всех ролей
        public IActionResult Index()
        {
            var roles = rolesManager.Roles.ToList();
            return View(roles.Select(role => new RoleViewModel { Name = role.Name }).ToList());
        }

        // добавить роль
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleViewModel role)
        {
            var result = await rolesManager.CreateAsync(new IdentityRole(role.Name));
            if (result.Succeeded)
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

        // удалить роль
        public async Task<IActionResult> RemoveAsync(string name)
        {
            if (name != "Admin" && name != "User")
            {
                var role = await rolesManager.FindByNameAsync(name);
                await rolesManager.DeleteAsync(role);
            }            
            return RedirectToAction(nameof(Index));
        }
    }
}