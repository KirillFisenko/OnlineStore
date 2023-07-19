namespace OnlineShopWebApp.Models
{
	public class Order
	{
		public Guid Id { get; set; }		
		public Cart Cart { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
	}
}
