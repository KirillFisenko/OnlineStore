using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
			return View(users);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Register user)
		{
			var userAccount = usersRepository.TryGetByName(user.UserName);
			if (userAccount != null)
			{
				ModelState.AddModelError("", "Пользователь с таким именем уже есть.");
			}
			if (user.UserName == user.Password)
			{
				ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
			}
			if (!user.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
			{
				ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
			}
			if (!user.FirstName.All(char.IsLetter))
			{
				ModelState.AddModelError("", "Имя должно содержать только буквы");
			}
			if (!user.LastName.All(char.IsLetter))
			{
				ModelState.AddModelError("", "Фамилия должна содержать только буквы");
			}
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			usersRepository.Add(Mapping.ToUserDb(new UserViewModel(user.UserName, user.Password, user.FirstName, user.LastName, user.Phone)));
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
			usersRepository.Edit(Mapping.ToEditUserDb(user), userId);
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