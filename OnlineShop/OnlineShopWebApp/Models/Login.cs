using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]       
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]        
        public string Password { get; set; }
        public bool RememberMe { get; set; }        
    }
}