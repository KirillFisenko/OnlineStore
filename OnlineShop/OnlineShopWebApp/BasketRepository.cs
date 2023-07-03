using OnlineShopWebApp.Models;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApp
{
    public class BasketRepository
    {
        public static List<Basket> basket = new List<Basket>();

        public List<Basket> GetAll()
        {
            return basket;
        }

        public void AddProductToBasket(int id)
        {
            var product = ProductRepository.products.FirstOrDefault(product => product.Id == id);
            var newProductInBasket = new Basket(product.Name, 1, product.Cost);
            var isProductInBasket = basket.FirstOrDefault(product => product.ProductName == newProductInBasket.ProductName);            
            if (isProductInBasket != null)
            {
                isProductInBasket.ProductCount++;                
            }
            else
            {
                BasketRepository.basket.Add(newProductInBasket);
            }
        }

        public decimal GetSum(List<Basket> basket)
        {
            decimal sum = 0;
            foreach (var basketItem in basket)
            {
                sum += basketItem.ProductCount * basketItem.ProductCost;
            }
            return sum;
        }
    }
}