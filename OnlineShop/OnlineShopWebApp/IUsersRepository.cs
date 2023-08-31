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
        void Update(User product, string name);
    }
}