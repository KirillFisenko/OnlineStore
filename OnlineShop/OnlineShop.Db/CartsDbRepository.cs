using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	public class CartsDbRepository : ICartsRepository
	{
		private readonly DatabaseContext databaseContext;

		public CartsDbRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		public Cart TryGetById(string userId)
		{
			return databaseContext.Carts
				.Include(x => x.Items)
				.ThenInclude(x => x.Product)
				.FirstOrDefault(cart => cart.UserId == userId);
		}

		public void Add(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
			if (existingCart == null)
			{
				var newCart = new Cart
				{
					UserId = userId
				};

				newCart.Items = new List<CartItem>
					{
						new CartItem()
						{
							Quantity = 1,
							Product = product
						}
					};
				databaseContext.Carts.Add(newCart);
			}
			else
			{
				var existingCartItem = existingCart.Items
					.FirstOrDefault(item => item.Product.Id == product.Id);
				if (existingCartItem != null)
				{
					existingCartItem.Quantity++;
				}
				else
				{
					existingCart.Items.Add(new CartItem
					{
						Quantity = 1,
						Product = product
					});
				}
			}
			databaseContext.SaveChanges();
		}

		public void DecreaseAmount(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
			var existingCartItem = existingCart?.Items?
				.FirstOrDefault(item => item.Product.Id == product.Id);
			if (existingCartItem == null)
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
				databaseContext.Carts.Remove(existingCart);
			}
			databaseContext.SaveChanges();
		}

		public void Remove(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
			var existingCartItem = existingCart?.Items?
				.FirstOrDefault(item => item.Product.Id == product.Id);
			existingCart.Items.Remove(existingCartItem);
			databaseContext.SaveChanges();
		}

		public void Clear(string userId)
		{
			var existingCart = TryGetById(userId);
			databaseContext.Carts.Remove(existingCart);
			databaseContext.SaveChanges();
		}
	}
}