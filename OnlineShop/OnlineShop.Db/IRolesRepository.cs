using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IRolesRepository
	{
		void Add(Role role);
		void Del(string Name);
		List<Role> GetAll();
		Role TryGetByName(string Name);
	}
}