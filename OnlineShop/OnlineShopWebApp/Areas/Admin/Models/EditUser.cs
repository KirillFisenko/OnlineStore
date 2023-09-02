using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditUser
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Имя пользователя должно содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string? UserName { get; set; }        

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Имя пользователя должно содержать от 1 до 200 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указано фамилия пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Фамилия пользователя должно содержать от 1 до 200 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должно содержать от 5 до 50 символов")]
        public string Phone { get; set; }
    }
}