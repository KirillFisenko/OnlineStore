namespace OnlineShop.Db.Models
{
	public class Product
	{	
		public Guid Id { get; set; }        
        public string Name { get; set; }      	
		public decimal Cost { get; set; }
		public string Description { get; set; }  
		public string ImagePath { get; set; }	
		public List<CartItem> CartItems { get; set;}

		public Product()
		{
			CartItems = new List<CartItem>();
		}

		public Product(string Name, decimal Cost, string Description, string ImagePath)
		{
			Id = Guid.NewGuid();
			this.Name = Name;
			this.Cost = Cost;
			this.Description = Description;
			this.ImagePath = ImagePath;			
		}
	}
}