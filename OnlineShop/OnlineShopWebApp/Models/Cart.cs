namespace OnlineShopWebApp.Models
{
	public class Cart
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public List<CartItem> Items { get; set; }
		public decimal Cost
		{
			get
			{
				return Items?.Sum(item => item.Cost) ?? 0;
			}
		}
		public int Amount
		{
			get
			{
				return Items?.Sum(item => item.Amount) ?? 0;
			}
		}
	}	
}