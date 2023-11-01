using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? Email { get; set; }               
    }
}
