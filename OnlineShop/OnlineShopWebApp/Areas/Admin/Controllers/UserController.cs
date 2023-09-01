using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {        
        private readonly IUsersRepository usersRepository;
        public UserController(IUsersRepository usersRepository)
        {            
            this.usersRepository = usersRepository;
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
		public IActionResult Add(User user)
		{
			if (usersRepository.TryGetByName(user.Email) != null)
			{
				ModelState.AddModelError("", "Пользователь с таким Email уже существует");
			}
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			usersRepository.Add(user);
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
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user, Guid userId)
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
            return View(user);
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
            return View(user);
        }

        [HttpPost]
        public IActionResult ChangeAccess(Guid userId, string roleName)
        {
            usersRepository.ChangeAccess(userId, roleName);
            return RedirectToAction(nameof(Index));
        }       
    }
}