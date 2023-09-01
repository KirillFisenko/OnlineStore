using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IUsersRepository
	{
		List<User> GetAllUsers();
        User TryGetById(Guid userId);
        User TryGetByName(string name);
        void Del(Guid userId);
        void Add(User user);
        void Update(User user, Guid userId);
        void ChangePassword(Guid userId, string password);
        void ChangeAccess(Guid userId, string roleName);
    }
}