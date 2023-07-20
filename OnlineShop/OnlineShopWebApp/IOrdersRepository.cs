using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Cart cart);
    }
}