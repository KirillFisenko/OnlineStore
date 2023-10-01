using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public RoleViewModel Role { get; set; }

        public UserViewModel()
        { }

        public UserViewModel(string name, string password, string firstName, string lastName, string phone)
        {
            Id = Guid.NewGuid();
            Role = new RoleViewModel("User");
            Name = name;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}