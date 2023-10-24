namespace OnlineShop.Db.Models
{
	// Избранные продукты в БД, привязаны к UserId
	public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Product? Product { get; set; }
    }
}