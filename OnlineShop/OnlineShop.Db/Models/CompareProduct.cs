namespace OnlineShop.Db.Models
{
    // модель продукта для сравнения в БД
    public class CompareProduct
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Product? Product { get; set; }
    }
}