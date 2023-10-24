using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    // модель пользователя в БД, используется ASP.NET Core Identity
    public class User : IdentityUser
    {
        // Имя
        public string? FirstName { get; set; }

        // Адрес
        public string? Address { get; set; }

        // Ссылка на аватар
        public string? AvatarUrl { get; set; }       
    }
}