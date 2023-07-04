namespace OnlineShopWebApp.Models
{
    public class User
    {
        private static int instanceCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public static List<Product> ShoppingList { get; set; }
        public User(string name)
        {
            Name = name;
            Id = instanceCounter;
            instanceCounter++;
        }
    }
}
