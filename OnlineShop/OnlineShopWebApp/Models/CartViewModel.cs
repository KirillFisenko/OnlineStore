namespace OnlineShop.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public List<CartItemViewModel>? Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(item => item.Amount) ?? 0;
            }
        }
        public int Quantity
        {
            get
            {
                return Items?.Sum(item => item.Quantity) ?? 0;
            }
        }
    }
}