using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public interface IRolesRepository
	{
		void Add(Roles role);		
		void Del(Roles role);
		List<Roles> GetAllRoles();
	}
}