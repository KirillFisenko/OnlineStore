namespace OnlineShopWebApp.Models
{
	public class Product
	{
		private static int instanceCounter = 2506;
		public int Id { get; }
		public string Name { get; }
		public decimal Cost { get; }
		public string Description { get; }
		public string ImagePath { get; }

		//спецификация
		public string Interface { get; }
		public string FrequencyGPU { get; }
		public string FrequencyGPUBoost { get; }
		public string MemoryCapacity { get; }
        public string MemoryType { get; }
        public string FrequencyMemory { get; }
		public string MemoryBus { get; }
		public string Connectors { get; }
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