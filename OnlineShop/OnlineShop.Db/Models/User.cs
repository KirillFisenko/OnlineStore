using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }       
    }
}