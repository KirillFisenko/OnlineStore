using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	// модель данных при регистрации пользователя с валидацией с помощью атрибутов
	public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmPassword { get; set; }       

        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должен содержать от 5 до 50 символов")]
        public string? PhoneNumber { get; set; }	
        
        // загружаемый файл аватарки
		public IFormFile? UploadedFile { get; set; }

		// ссылка на которую вернуть пользователя после регистрации
		public string? ReturnUrl { get; set; }

        // имя
        public string? FirstName { get; set; }

        // адрес
        public string? Address { get; set; }
    }
}