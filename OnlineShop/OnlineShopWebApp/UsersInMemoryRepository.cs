using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class UsersInMemoryRepository : IUsersRepository
    {
        private readonly List<User> users = new List<User>()
        {
            new User("kirill@kirill.ru", "12345678", "Кирилл", "Фисенко", "+79265846357"),
            new User("andrey@andrey.ru", "12345678", "Андрей", "Петров", "+79164875124")
            };

        public List<User> GetAll()
        {
            return users;
        }

        public User TryGetById(Guid usertId)
        {
            return users.FirstOrDefault(user => user.Id == usertId);
        }

        public User TryGetByName(string name)
        {
            return users.FirstOrDefault(user => user.Name == name);
        }

        public void Del(Guid usertId)
        {
            var user = TryGetById(usertId);
            users.Remove(user);
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Edit(EditUser user, Guid userId)
        {
            var currentUser = TryGetById(userId);
            currentUser.Name = user.UserName;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Phone = user.Phone;            
        }

        public void ChangePassword(Guid userId, string password)
        {
            var currentUser = TryGetById(userId);
            currentUser.Password = password;
        }

        public void ChangeAccess(Guid userId, string roleName)
        {
            var currentUser = TryGetById(userId);
            currentUser.Role.Name = roleName;
        }
    }
}