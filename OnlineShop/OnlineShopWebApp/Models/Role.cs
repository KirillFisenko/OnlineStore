using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Не указано имя роли")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Имя роли должно содержать от 1 до 50 символов")]
        public string Name { get; set; }

        public Role() { }
        public Role(string name)
        {
            Name = name;
        }
    }
}
