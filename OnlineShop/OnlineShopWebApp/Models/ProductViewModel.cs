using OnlineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано наименование товара")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Наименование должно содержать от 3 до 70 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена товара")]
        [Range(1, 999_999, ErrorMessage = "Цена товара должна быть в диапазоне 1 - 999 999 р.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание товара")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Описание должно содержать от 1 до 300 символов")]
        public string Description { get; set; }

        public List<ImageViewModel> Images { get; set; }

		public CategoriesViewModel Categories { get; set; }
	}
}