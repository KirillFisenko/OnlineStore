using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	// модель данных при идентификации и аутентификации пользователя с валидацией с помощью атрибутов
	public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]        
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string? Password { get; set; }
        
        // галочка "запомнить меня"
        public bool RememberMe { get; set; }

        // ссылка на которую вернуть пользователя после входа
        public string? ReturnUrl { get; set; }
    }
}