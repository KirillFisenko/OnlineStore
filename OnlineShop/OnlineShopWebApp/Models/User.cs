using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Models
{
	public class User
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }       
        public string Password { get; set; }           
        public string FirstName { get; set; }       
        public string LastName { get; set; }        
        public string Phone { get; set; }
        public Role Role { get; set; }

        public User(string name, string password, string firstName, string lastName, string phone)
        {
            Id = Guid.NewGuid();
            Role = new Role("User");
            Name = name;
            Password = password;            
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}