using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmPassword { get; set; }
        
        public string? Code { get; set; }
    }
}
