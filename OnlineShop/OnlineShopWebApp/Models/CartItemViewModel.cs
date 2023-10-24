namespace OnlineShopWebApp.Models
{
    // модель карточки продукта для представления
    public class CartItemViewModel
    {                
        public ProductViewModel? Product { get; set; }

        // количество продукта
        public int Quantity { get; set; }

        // автосвойство для расчета суммы по одной карточке
        public decimal? Amount
        {
            get
            {
                return Product?.Cost * Quantity;
            }
        }
    }
}