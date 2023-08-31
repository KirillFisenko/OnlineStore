using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class UsersInMemoryRepository : IUsersRepository
    {
        private readonly List<User> users = new List<User>()
        {
            new User("kirill@kirill.ru", "12345678"),
            new User("Semen@Semen", "12345678"),
            new User("Igor@Igor", "12345678")
            };

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User TryGetById(Guid usertId)
        {
            return users.FirstOrDefault(user => user.Id == usertId);
        }

        public User TryGetByName(string name)
        {
            return users.FirstOrDefault(user => user.Email == name);
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

        public void Update(User user, string name)
        {
            var currentUser = TryGetByName(name);
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Phone = user.Phone;
        }
    }
}