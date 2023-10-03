using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class UsersDbRepository : IUsersRepository
    {
        private readonly DatabaseContext databaseContext;

        public UsersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<User> GetAll()
        {
            return databaseContext.Users.Include(x => x.Role).ToList();
        }

        public User TryGetById(Guid usertId)
        {
            return databaseContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(user => user.Id == usertId);
        }

        public User TryGetByName(string name)
        {
            return databaseContext.Users.FirstOrDefault(user => user.Name == name);
        }

        public void Remove(Guid usertId)
        {
            var user = TryGetById(usertId);
            databaseContext.Users.Remove(user);
            databaseContext.SaveChanges();
        }

        public void Add(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public void Edit(EditUser user, Guid userId)
        {
            var currentUser = TryGetById(userId);
            currentUser.Name = user.UserName;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Phone = user.Phone;
            databaseContext.SaveChanges();
        }

        public void ChangePassword(Guid userId, string password)
        {
            var currentUser = TryGetById(userId);
            currentUser.Password = password;
            databaseContext.SaveChanges();
        }

        public void ChangeAccess(Guid userId, string roleName)
        {
            var currentUser = TryGetById(userId);
            currentUser.Role.Name = roleName;
            databaseContext.SaveChanges();
        }
    }
}