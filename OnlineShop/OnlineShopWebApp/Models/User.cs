using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage = "Не корректный Email")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Наименование должно содержать от 3 до 70 символов")]
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        [Required(ErrorMessage = "Не указано имя")]      
        [StringLength(70, MinimumLength = 1, ErrorMessage = "Имя должно содержать от 1 до 70 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "Фамилия должна содержать от 1 до 70 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указана телефон")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "Телефон должен содержать от 1 до 70 символов")]
        public string Phone { get; set; }

        public User()
        {
            
        }
        public User(string name, string password) : this()
        {           
            Id = Guid.NewGuid();
            Email = name;
            Password = password;
            Role = new Role("User");
        }
    }
}
