using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.AccountViewComponent
{
	// компонента представления аватара пользователя
	public class AccountViewComponent : ViewComponent
	{
        private readonly UserManager<User> userManager;        
        private readonly IMapper mapper;

		public AccountViewComponent(UserManager<User> userManager, IMapper mapper)
		{			
			this.userManager = userManager;			
			this.mapper = mapper;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await userManager.FindByNameAsync(User.Identity.Name);
			var userViewModel = mapper.Map<UserViewModel>(user);			
            var userAvatar = userViewModel.AvatarUrl;
			if (userAvatar == null)
			{
				userAvatar = "/images/Profiles/default.png";
			}
			return View("Account", userAvatar);
		}		
	}
}