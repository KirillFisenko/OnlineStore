using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class IdentityInitializer
	{
		public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			var adminEmail = "admin@gmail.com";
			var password = "adminADMIN123$";
			if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
			}
			if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
			}
			if (roleManager.FindByNameAsync(adminEmail).Result == null)
			{
				var admin = new User { Email = adminEmail, UserName = adminEmail, Name = adminEmail, Phone = "896254357" };
				var result = userManager.CreateAsync(admin, password).Result;
				if(result.Succeeded)
				{
					userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
				}
			}
		}
	}
}