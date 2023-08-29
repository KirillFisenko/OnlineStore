using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IRolesRepository
	{
		void Add(Role role);		
		void Remove(string Name);
		List<Role> GetAllRoles();
		Role TryGetByName(string Name);
	}
}