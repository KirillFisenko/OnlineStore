namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal? Amount { get; set; }       
        public string Date { get; set; }
        public string Time { get; set; }
        public OrderStatuses Status { get; set; }

        public Order()
        {
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            Status = OrderStatuses.Created;
        }
    }
}