using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class IndentityContext : IdentityDbContext<User>
	{
		public IndentityContext(DbContextOptions<IndentityContext> options) : base(options)
		{
			Database.Migrate();
		}
	}
}