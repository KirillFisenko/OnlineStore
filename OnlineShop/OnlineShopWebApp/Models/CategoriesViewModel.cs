using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
	// перечисление категорий продуктов в представлении
	public enum CategoriesViewModel
    {
        [Display(Name = "Процессоры")]
        Processors,
        [Display(Name = "Материнские платы")]
        Motherboards,
        [Display(Name = "Видеокарты")]
        VideoCards,
        [Display(Name = "HDD")]
        HDD,
        [Display(Name = "SSD")]
        SSD,
        [Display(Name = "Оперативная память")]
        ROM,
        [Display(Name = "Корпуса")]
        Enclosures,
        [Display(Name = "Блоки питания")]
        PowerSupplies,
        [Display(Name = "Системы охлаждения")]
        CoolingSystems,
        [Display(Name = "Оптические приводы")]
        OpticalDrives,
        [Display(Name = "Звуковые карты")]
        SoundCards,
        [Display(Name = "Аксессуары и моддинг")]
        AccessoriesAndModding,
        [Display(Name = "Программное обеспечение")]
        Software
    }
}
