using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp
{
    public interface IRolesRepository
	{
		void Add(Role role);		
		void Del(string Name);
		List<Role> GetAll();
		Role TryGetByName(string Name);
	}
}