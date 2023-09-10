using OnlineShop.Areas.Admin.Models;

namespace OnlineShop
{
    public interface IRolesRepository
	{
		void Add(Role role);		
		void Del(string Name);
		List<Role> GetAll();
		Role TryGetByName(string Name);
	}
}