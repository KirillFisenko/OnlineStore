using static System.Net.Mime.MediaTypeNames;

namespace OnlineShop.Db.Models
{
	public class Product
	{	
		public Guid Id { get; set; }        
        public string Name { get; set; }      	
		public decimal Cost { get; set; }
		public string Description { get; set; }  
		public List<CartItem> CartItems { get; set;}

		public List<Image> Images { get; set; }
		
		public Product(Guid id, string Name, decimal Cost, string Description) : this()
		{
			Id = id;
			this.Name = Name;
			this.Cost = Cost;
			this.Description = Description;					
		}

		public Product()
		{
			CartItems = new List<CartItem>();
			Images = new List<Image>();
		}
	}
}