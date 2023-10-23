namespace OnlineShopWebApp.Models
{
    // одна позиция в корине
    public class CartItemViewModel
    {                
        public ProductViewModel? Product { get; set; }

        // количество единиц продукта
        public int Quantity { get; set; }

        // автосвойство для расчета суммы по одной позиции в корзине
        public decimal? Amount
        {
            get
            {
                return Product?.Cost * Quantity;
            }
        }
    }
}