namespace OnlineShopWebApp
{
	public class InMemoryConstants : IConstants
	{
		public string _UserId = "UserId";
		public string UserId { get { return _UserId; } }
	}

	public interface IConstants
	{
		public string UserId { get; }
	}
}
