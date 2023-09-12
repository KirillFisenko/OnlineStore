using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class RolesDbRepository : IRolesRepository
    {
        private readonly DatabaseContext databaseContext;

        public RolesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Role> GetAll()
        {
            return databaseContext.Roles.ToList();
        }

        public void Add(Role role)
        {
            databaseContext.Roles.Add(role);
            databaseContext.SaveChanges();
        }

        public void Del(string roleName)
        {
            var role = databaseContext.Roles.FirstOrDefault(x => x.Name == roleName);
            databaseContext.Roles.Remove(role);            
            databaseContext.SaveChanges();
        }

        public Role TryGetByName(string roleName)
        {
            return databaseContext.Roles.FirstOrDefault(role => role.Name == roleName);
        }
    }
}