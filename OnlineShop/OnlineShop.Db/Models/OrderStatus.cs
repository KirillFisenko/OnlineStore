namespace OnlineShop.Db.Models
{
    // перечесление статусов заказа в БД
    public enum OrderStatus
    {        
        Created,        
        Processed,       
        Delivering,       
        Delivered,       
        Canceled
    }
}