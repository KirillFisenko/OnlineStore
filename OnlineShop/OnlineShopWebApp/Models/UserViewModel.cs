namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {        
        public string UserName { get; set; }              
        public string PhoneNumber { get; set; }
		public string? FirstName { get; set; }
		public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
    }
}