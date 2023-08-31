using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>() { new Role("Admin"), new Role("User") };

        public List<Role> GetAllRoles()
        {
            return roles;
        }

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public void Remove(string roleName)
        {
            roles.RemoveAll(role => role.Name == roleName);
        }

        public Role TryGetByName(string roleName)
        {
            return roles.FirstOrDefault(role => role.Name == roleName);
        }
    }
}