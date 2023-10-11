using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]        
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}