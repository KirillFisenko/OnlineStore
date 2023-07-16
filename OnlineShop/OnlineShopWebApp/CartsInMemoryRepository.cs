using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class CartsInMemoryRepository : ICartsRepository
	{
		public List<Cart> carts = new List<Cart>();

		public Cart TryGetByUserId(string userId)
		{
			return carts.FirstOrDefault(cart => cart.UserId == userId);
		}

		public void Add(Product product, string userId)
		{
			var existingCart = TryGetByUserId(userId);
			if (existingCart == null)
			{
				var newCart = new Cart()
				{
					Id = Guid.NewGuid(),
					UserId = userId,
					Items = new List<CartItem>
					{
						new CartItem()
						{
							Id = Guid.NewGuid(),
							Amount = 1,
							Product = product
						}
					}
				};
				carts.Add(newCart);
			}
			else
			{
				var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
				if (existingCartItem != null)
				{
					existingCartItem.Amount++;
				}
				else
				{
					existingCart.Items.Add(new CartItem
					{
						Id = Guid.NewGuid(),
						Amount = 1,
						Product = product
					});
				}
			}
		}
	}
}