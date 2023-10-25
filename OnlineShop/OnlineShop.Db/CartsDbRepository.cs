using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// репозиторий корзин в БД
	public class CartsDbRepository : ICartsRepository
	{
		private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

		// получить корзину пользователя
        public Cart TryGetByUserId(string? userId)
		{
			return databaseContext.Carts
				.Include(x => x.Items)
				.ThenInclude(x => x.Product)
				.FirstOrDefault(cart => cart.UserId == userId);
		}

		// добавить продукт в корзину пользователя
		public void Add(Product product, string? userId)
		{
			var existingCart = TryGetByUserId(userId);
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
					.FirstOrDefault(item => item.Product?.Id == product.Id);
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

		// уменьшить количество товара в корзине, если 1 шт. - удалить товар, если корзина пустая - удалить ее
		public void DecreaseAmount(Product product, string userId)
		{
			var existingCart = TryGetByUserId(userId);			
			var existingCartItem = existingCart?.Items?
				.FirstOrDefault(item => item.Product?.Id == product.Id);
			if(existingCartItem == null)
			{
				return;
			}
			existingCartItem.Quantity--;
			if (existingCartItem.Quantity == 0)
			{
				existingCart?.Items.Remove(existingCartItem);
			}
			if (existingCart?.Items.Count == 0)
			{
                databaseContext.Carts.Remove(existingCart);
			}
            databaseContext.SaveChanges();
        }

		// очистить корзину пользователя
		public void Clear(string userId)
		{
			var existingCart = TryGetByUserId(userId);
			databaseContext.Carts.Remove(existingCart);
			databaseContext.SaveChanges();
		}
	}
}