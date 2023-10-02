using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

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
			return View(users.ToUserViewModels());
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
			}
			if (register.UserName == register.Password)
			{
				ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
			}
			if (!register.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
			{
				ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
			}
			if (!register.FirstName.All(char.IsLetter))
			{
				ModelState.AddModelError("", "Имя должно содержать только буквы");
			}
			if (!register.LastName.All(char.IsLetter))
			{
				ModelState.AddModelError("", "Фамилия должна содержать только буквы");
			}
			if (!ModelState.IsValid)
			{
				return View(register);
			}
			var newUser = new User
			{
				Id = Guid.NewGuid(),
				Name = register.UserName,
				Password = register.Password,
				FirstName = register.FirstName,
				LastName = register.LastName,
				Phone = register.Phone,
				Role = new Role {  Name = "User" }
			};
			usersRepository.Add(newUser);
            return RedirectToAction(nameof(Index));
		}

		public IActionResult Details(Guid userId)
		{
			var user = usersRepository.TryGetById(userId);
			return View(user.ToUserViewModel());
		}

		public IActionResult Remove(Guid userId)
		{
			usersRepository.Remove(userId);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(Guid userId)
		{
			var user = usersRepository.TryGetById(userId);
			var editUser = new EditUserViewModel
			{
				Id = user.Id,
				UserName = user.Name,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Phone = user.Phone
			};
			return View(editUser);
		}

		[HttpPost]
		public IActionResult Edit(EditUserViewModel user, Guid userId)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			usersRepository.Edit(Mapping.ToUser(user), userId);
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
			return View(roles.ToRoleViewModels());
		}

		[HttpPost]
		public IActionResult ChangeAccess(Guid userId, string role)
		{
			usersRepository.ChangeAccess(userId, role);
			return RedirectToAction(nameof(Index));
		}
	}
}