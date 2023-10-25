namespace OnlineShopWebApp.Models
{
	// модель всех списков для представления
	public class AllListsProductViewModel
	{
		// список всех продуктов в магазине
		public List<ProductViewModel>? productsViewModel { get; set; }

		// список продуктов в избранном у пользователя
		public List<ProductViewModel>? favoriteProductsViewModel { get; set; }

		// список продуктов для сравнения у пользователя
		public List<ProductViewModel>? compareProductsViewModel { get; set; }

		// корзина пользователя
		public CartViewModel? cartViewModel { get; set; }
	}
}
