namespace OnlineShopWebApp.Models
{
    // модель корзины для представления
    public class CartViewModel
    {        
        public string? UserId { get; set; }
        public List<CartItemViewModel>? Items { get; set; }

        // автосвойство для расчета суммы корзины
        public decimal Amount
        {
            get
            {
                return Items?.Sum(item => item.Amount) ?? 0;
            }
        }
        // автосвойство для расчета количества товаров в корзине (для компоненты представления) 
        public int Quantity
        {
            get
            {
                return Items?.Sum(item => item.Quantity) ?? 0;
            }
        }
    }
}