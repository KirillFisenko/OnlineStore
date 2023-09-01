using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class CartsInMemoryRepository : ICartsRepository
	{
        private readonly List<Cart> carts = new List<Cart>();

		public Cart TryGetById(string userId)
		{
			return carts.FirstOrDefault(cart => cart.UserId == userId);
		}

		public void Add(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
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
							Quantity = 1,
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
					existingCartItem.Quantity++;
				}
				else
				{
					existingCart.Items.Add(new CartItem
					{
						Id = Guid.NewGuid(),
						Quantity = 1,
						Product = product
					});
				}
			}
		}

		public void DecreaseAmount(Product product, string userId)
		{
			var existingCart = TryGetById(userId);			
			var existingCartItem = existingCart?.Items?.FirstOrDefault(item => item.Product.Id == product.Id);
			if(existingCartItem == null)
			{
				return;
			}
			existingCartItem.Quantity--;
			if (existingCartItem.Quantity == 0)
			{
				existingCart.Items.Remove(existingCartItem);
			}
			if (existingCart.Items.Count == 0)
			{
				carts.Remove(existingCart);
			}
		}

		public void Clear(string userId)
		{
			var existingCart = TryGetById(userId);
			carts.Remove(existingCart);
		}
	}
}