using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    { 
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
		public string UserName { get; set; }
	}
}