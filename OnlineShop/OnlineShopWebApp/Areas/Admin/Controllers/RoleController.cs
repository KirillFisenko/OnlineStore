using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles.ToRoleViewModels());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel role)
        {
            if (!role.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "Роль должна содержать только буквы");
            }
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            rolesRepository.Add(role.ToRole());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(string name)
        {
            rolesRepository.Remove(name);
            return RedirectToAction(nameof(Index));
        }
    }
}