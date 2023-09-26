namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public UserDeliveryInfoViewModel User { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        public decimal? Amount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
            set { }
        }
        public string Date { get; set; }
        public string Time { get; set; }
        public OrderStatusesViewModel Status { get; set; }

        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            Status = OrderStatusesViewModel.Created;
        }
    }
}