using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
	// интерфейс корзины
	public interface ICartsRepository
	{
        // получить корзину пользователя
        Task<Cart> TryGetByUserIdAsync(string? userId);

        // добавить продукт в корзину пользователя
        Task AddAsync(Product product, string userId);

        // уменьшить количество товара в корзине, если 1 шт. - удалить товар, если корзина пустая - удалить ее
        Task DecreaseAmountAsync(Product product, string userId);

        // очистить корзину пользователя
        Task ClearAsync(string? userId);       
	}
}