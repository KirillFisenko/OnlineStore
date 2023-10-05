using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class RoleViewModel
    {       
        [Required(ErrorMessage = "Не указано имя роли")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Имя роли должно содержать от 1 до 50 символов")]
        public string Name { get; set; }  
        
        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return role.Name == Name;
        }
    }
}