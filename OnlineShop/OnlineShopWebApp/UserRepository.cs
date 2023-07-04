using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class UserRepository
    {        
        public void AddProductToUserList(int id)
        {
            User.ShoppingList.Add(ProductRepository.products.FirstOrDefault(product => product.Id == id));
        }

        public decimal SumPriceUserShoppingList()
        {                   
            return User.ShoppingList.Sum(product => product.Cost);
        }

        public List<Product> GetUserShoppingList()
        {
            return User.ShoppingList;
        }
    }
}
