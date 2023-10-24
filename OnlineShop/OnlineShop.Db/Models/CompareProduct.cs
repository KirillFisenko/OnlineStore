namespace OnlineShop.Db.Models
{
    // Продукт для сравнения в БД, привязан к UserId
    public class CompareProduct
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Product? Product { get; set; }
    }
}