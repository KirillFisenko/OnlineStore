using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {        
        private readonly IUsersRepository usersRepository;
        private readonly IRolesRepository rolesRepository;
        public UserController(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {            
            this.usersRepository = usersRepository;
            this.rolesRepository = rolesRepository;
        }        
       
        public IActionResult Index()
        {
            var users = usersRepository.GetAll();
            return View(users);
        }

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Register register)
		{
            var userAccount = usersRepository.TryGetByName(register.UserName);
            if (userAccount != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже есть.");
                return View(register);
            }
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
                return View(register);
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            usersRepository.Add(new User(register.UserName, register.Password, register.FirstName, register.LastName, register.Phone));
            return RedirectToAction(nameof(Index));
		}		

		public IActionResult Details(Guid userId)
        {
            var user = usersRepository.TryGetById(userId);
            return View(user);
        }

        public IActionResult Del(Guid userId)
        {
            usersRepository.Del(userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid userId)
        {
            var user = usersRepository.TryGetById(userId);
            var editUser = new EditUser();
            editUser.UserName = user.Name;
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Phone = user.Phone;
            ViewData["userId"] = userId;
            return View(editUser);
        }

        [HttpPost]
        public IActionResult Edit(EditUser user, Guid userId)
        {            
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            usersRepository.Edit(user, userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword(Guid userId)
        {
            var user = usersRepository.TryGetById(userId);
            ViewData["userId"] = userId;
            ViewData["userName"] = user.Name;
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(Guid userId, string password)
        {
            usersRepository.ChangePassword(userId, password);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangeAccess(Guid userId)
        {
            var user = usersRepository.TryGetById(userId);
            var roles = rolesRepository.GetAll();
            ViewData["userId"] = userId;
            ViewData["userName"] = user.Name;
            ViewData["userRole"] = user.Role.Name;
            return View(roles);
        }

        [HttpPost]
        public IActionResult ChangeAccess(Guid userId, string role)
        {
            usersRepository.ChangeAccess(userId, role);
            return RedirectToAction(nameof(Index));
        }
    }
}