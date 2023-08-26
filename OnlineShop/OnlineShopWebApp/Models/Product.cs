using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class Product
	{
		private static int instanceCounter = 2506;
		public int Id { get; }

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

        //спецификация
        public string Interface { get; set; }
        public string FrequencyGPU { get; set; }
        public string FrequencyGPUBoost { get; set; }
        public string MemoryCapacity { get; set; }
        public string MemoryType { get; set; }
        public string FrequencyMemory { get; set; }
        public string MemoryBus { get; set; }
        public string Connectors { get; set; }
        //спецификация

        public Product(string name, decimal cost, string description, string imagePath)
		{
			Id = instanceCounter;
			Name = name;
			Cost = cost;
			Description = description;
			ImagePath = imagePath;
			instanceCounter++;
			var specifications = Description.Split("; ");

			Interface = specifications[0];
			FrequencyGPU = specifications[1];
			FrequencyGPUBoost = specifications[2];
			MemoryCapacity = specifications[3];
            MemoryType = specifications[4];
            FrequencyMemory = specifications[5];
			MemoryBus = specifications[6];
			Connectors = specifications[7];
		}
	}
}