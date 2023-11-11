
namespace OnlineShop.Db.Models
{
	// модель продукта в БД
	public class Product
	{	
		public Guid Id { get; set; }

		// связь "один ко многим" - один продукт может быть в нескольких карточках товара
		public List<CartItem> CartItems { get; set; }

		// наименование продукта
		public string? Name { get; set; }      
		
		// стоимость продукта
		public decimal Cost { get; set; }

		// описание продукта
		public string? Description { get; set; }
		
		// список изображений товара
		public List<Image> Images { get; set; }        

		// категория продукта
		public Categories Categories { get; set; }


		// конструктор для создания начальных продуктов в DatabaseContext
		public Product(Guid id, string Name, decimal Cost, string Description, Categories Categories) : this()
		{
			Id = id;
			this.Name = Name;
			this.Cost = Cost;
			this.Description = Description;
			this.Categories = Categories;
        }

		// конструктор по умолчанию
		public Product()
		{
			CartItems = new List<CartItem>();
			Images = new List<Image>();
		}
	}
}