using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApp
{
    public class BasketRepository
    {
        public static List<Basket> baskets = new List<Basket>();

        public Basket GetUserBasket(User user)
        {
            return baskets.FirstOrDefault(basket => basket.UserBasket == user);
        }        

    }
}