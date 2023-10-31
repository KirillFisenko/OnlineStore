namespace OnlineShopWebApp.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, string subjtct, string message);
    }
}