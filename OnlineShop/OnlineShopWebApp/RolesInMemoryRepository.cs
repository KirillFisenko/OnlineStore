using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        public List<Role> roles = new List<Role>() { new Role("Admin") };

        public List<Role> GetAllRoles()
        {
            return roles;
        }

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(role => role.Name == name);
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(role => role.Name == name);
        }
    }
}