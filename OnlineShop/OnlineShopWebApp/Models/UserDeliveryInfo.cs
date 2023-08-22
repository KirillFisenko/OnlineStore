using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage ="Поле ФИО должно быть заполнено")]
        [StringLength(70, MinimumLength = 3, ErrorMessage ="ФИО должно содержать от 3 до 70 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле Email должно быть заполнено")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]        
        public string Phone { get; set; }
        [Required(ErrorMessage = "Поле Адрес должно быть заполнено")]
        public string Address { get; set; }
    }
}
