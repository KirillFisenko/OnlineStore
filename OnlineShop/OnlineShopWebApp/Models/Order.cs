using System.Reflection;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Amount
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            Status = "Создан";
        }
    }
}