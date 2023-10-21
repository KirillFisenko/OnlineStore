
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

		public Categories Categories { get; set; }

        public Product(Guid id, string Name, decimal Cost, string Description, Categories Сategories) : this()
		{
			Id = id;
			this.Name = Name;
			this.Cost = Cost;
			this.Description = Description;
			this.Categories = Сategories;
        }

		public Product()
		{
			CartItems = new List<CartItem>();
			Images = new List<Image>();
		}
	}
}