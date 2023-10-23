namespace OnlineShop.Db.Models
{
    // модель корзины в БД содержит ID пользователя и список позиций товаров
    public class Cart
    {        
        public Guid Id { get; set; }
        public string? UserId { get; set; }       
        public List<CartItem> Items { get; set; }
       
        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}