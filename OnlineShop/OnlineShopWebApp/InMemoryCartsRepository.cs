using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class InMemoryCartsRepository : ICartsRepository
	{
		public List<Cart> _carts = new List<Cart>();

		public Cart TryGetByUserId(string userId)
		{
			return _carts.FirstOrDefault(cart => cart.UserId == userId);
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
				_carts.Add(newCart);
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
		public List<Cart> carts
		{
			get
			{
				return _carts;
			}
		}
	}

	public interface ICartsRepository
	{
		public List<Cart> carts { get; }

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