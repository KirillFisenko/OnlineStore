using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditUserViewModel
    {
		[Required(ErrorMessage = "Не указано Email пользователя")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Email пользователя должен содержать от 3 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string UserName { get; set; }           

        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должен содержать от 5 до 50 символов")]
        public string Phone { get; set; }
    }
}