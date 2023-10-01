using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}