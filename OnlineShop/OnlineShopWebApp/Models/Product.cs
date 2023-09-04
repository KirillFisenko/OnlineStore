using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class Product
	{
		private static int instanceCounter = 54743;
		public int Id { get; set; }

        [Required(ErrorMessage = "Не указано наименование товара")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Наименование должно содержать от 3 до 70 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена товара")]
		[Range(1, 999_999, ErrorMessage = "Цена товара должна быть в диапазоне 1 - 999 999 р.")]		
		public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание товара")]
		[StringLength(300, MinimumLength = 1, ErrorMessage = "Описание должно содержать от 1 до 300 символов")]
		public string Description { get; set; }

        [Required(ErrorMessage = "Не указан путь изображения товара")]
		[StringLength(100, MinimumLength = 1, ErrorMessage = "Путь должен содержать от 1 до 100 символов")]
		public string ImagePath { get; set; }		

		public Product()
		{
            Id = instanceCounter;
            instanceCounter++;
        }
        public Product(string name, decimal cost, string description, string imagePath) : this()
		{			
			Name = name;
			Cost = cost;
			Description = description;
			ImagePath = imagePath;            
        }
	}
}