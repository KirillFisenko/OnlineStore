namespace OnlineShop.Db.Models
{
    // модель корзины в БД 
    public class Cart
    {        
        public Guid Id { get; set; }

		// id пользователя
		public string? UserId { get; set; }

		// список карточек товаров
		public List<CartItem> Items { get; set; }
       
        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}