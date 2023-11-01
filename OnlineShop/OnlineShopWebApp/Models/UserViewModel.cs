namespace OnlineShopWebApp.Models
{
    // модель пользователя для представления
    public class UserViewModel
    {
        // имя пользователя == Email из IdentityUser
        public string? UserName { get; set; }

        // подтвержден ли Email
        public bool EmailConfirmed { get; set; }

        // номер телефона из IdentityUser
        public string? PhoneNumber { get; set; }

        // Имя
        public string? FirstName { get; set; }

        // Адрес
        public string? Address { get; set; }

        // Ссылка на аватар
        public string? AvatarUrl { get; set; }
    }
}