using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public enum OrderStatus
    {        
        Created,        
        Processed,       
        Delivering,       
        Delivered,       
        Canceled
    }
}