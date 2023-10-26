using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    // Инициализация пользователя администаратора и ролей
    public class IdentityInitializer
    {        
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "proPConlineShop@gmail.com";
            var password = "adminADMIN123$";

            // создание роли администратора, если ее нет
            if (await roleManager.FindByNameAsync(Constants.AdminRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName));
            }
            // создание роли пользователя, если ее нет
            if (await roleManager.FindByNameAsync(Constants.UserRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName));
            }
            // создание пользователя админитсратора, если его нет
            if (await roleManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.AdminRoleName);
                }
            }
        }
    }
}
// Add-Migration Inizialization -context DatabaseContext
// Add-Migration Identity -context IdentityContext -OutputDir Migrations/Identity