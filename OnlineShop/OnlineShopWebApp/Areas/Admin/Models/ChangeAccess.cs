using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class ChangeAccess
    {
        [Required(ErrorMessage = "Не указана роль")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Роль должена содержать от 1 до 200 символов")]
        public string? Role { get; set; }        
    }
}
