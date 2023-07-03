namespace OnlineShopWebApp.Models
{
	public class Basket
	{
		public string ProductName { get; set; }
		public int ProductCount { get; set; }
		public decimal ProductCost { get; set; }

		public Basket(string productName, int productCount, decimal productCost)
		{
			ProductName = productName;
			ProductCount = productCount;
			ProductCost = productCost;
		}
	}
}