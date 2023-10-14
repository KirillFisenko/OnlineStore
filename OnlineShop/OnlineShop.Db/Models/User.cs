using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
		public string? FirstName { get; set; }			
		public string? Address { get; set; }
	}
}