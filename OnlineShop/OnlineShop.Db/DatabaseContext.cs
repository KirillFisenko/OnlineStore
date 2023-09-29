using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        // доступ к таблицам
        public DbSet<Product> Products { get; set; }        
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
		public DbSet<CompareProduct> CompareProducts { get; set; }
		public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }      

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated(); //создаем БД при первом обращении
        }        
    }
}