namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }              
        public DateTime CreateDateTime { get; set; }        
        public OrderStatus Status { get; set; }

        public Order()
        {
            CreateDateTime = DateTime.Now;            
            Status = OrderStatus.Created;
        }
    }
}