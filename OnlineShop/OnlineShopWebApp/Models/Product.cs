using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	public class Product
	{
		private static int instanceCounter = 2506;
		public int Id { get; }

        [Required(ErrorMessage = "Не указано имя товара")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Наименование должно содержать от 3 до 60 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена товара")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание товара")]        
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указан путь изображения товара")]
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