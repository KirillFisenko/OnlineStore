//using Microsoft.AspNetCore.Mvc;
//using OnlineShop.Db;
//using OnlineShop.Db.Models;
//using OnlineShopWebApp.Areas.Admin.Models;
//using OnlineShopWebApp.Helpers;

//namespace OnlineShopWebApp.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class RoleController : Controller
//    {      
//        private readonly IRolesRepository rolesRepository;
        
//        public RoleController(IRolesRepository rolesRepository)
//        {           
//            this.rolesRepository = rolesRepository;            
//        }

//        public IActionResult Index()
//        {
//            var roles = rolesRepository.GetAll();
//            return View(roles);
//        }

//        public IActionResult Add()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(RoleViewModel role)
//        {
//			if (!role.Name.All(c => char.IsLetter(c) || c == ' '))
//			{
//				ModelState.AddModelError("", "Роль должна содержать только буквы");
//			}
//			if (rolesRepository.TryGetByName(role.Name) != null)
//            {
//                ModelState.AddModelError("", "Такая роль уже существует");
//            }
//            if (!ModelState.IsValid)
//            {
//                return View(role);
//            }
//            rolesRepository.Add(Mapping.ToRoleDb(role));
//            return RedirectToAction(nameof(Index));
//        }

//        public IActionResult Del(string name)
//        {
//            rolesRepository.Del(name);
//            return RedirectToAction(nameof(Index));
//        }       
//    }
//}