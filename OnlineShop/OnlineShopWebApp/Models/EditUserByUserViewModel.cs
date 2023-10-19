namespace OnlineShopWebApp.Models
{
    public class EditUserByUserViewModel
    {
        public string PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
