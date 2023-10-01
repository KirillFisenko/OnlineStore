using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public interface IRolesRepository
	{
		void Add(Role role);
		void Remove(string Name);
		List<Role> GetAll();
		Role TryGetByName(string Name);
	}
}