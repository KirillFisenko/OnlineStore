using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditUserViewModel
    {
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Не указано Email пользователя")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Email пользователя должен содержать от 3 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? UserName { get; set; }        

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Имя пользователя должно содержать от 1 до 200 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Фамилия пользователя должна содержать от 1 до 200 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должен содержать от 5 до 50 символов")]
        public string Phone { get; set; }
    }
}