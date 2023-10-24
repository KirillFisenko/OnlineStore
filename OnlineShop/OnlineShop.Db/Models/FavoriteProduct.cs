namespace OnlineShop.Db.Models
{
	// модель избранного продукта в БД
	public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Product? Product { get; set; }
    }
}