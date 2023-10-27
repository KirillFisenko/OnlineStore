using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	// перечесление статусов заказа для представления
	public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "В пути")]
        Delivering,

        [Display(Name = "Доставлен")]
        Delivered,

        [Display(Name = "Отменен")]
        Canceled
    }
}