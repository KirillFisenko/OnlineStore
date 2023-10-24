namespace OnlineShop.Db.Models
{
	// модель изображения товара в БД
	public class Image
	{
		public Guid Id { get; set; }

		// путь до изображения
		public string? Url { get; set; }
		public Guid ProductId { get; set; }
		public Product? Product { get; set; }
	}
}
