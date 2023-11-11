namespace OnlineShop.Db.Models
{
    // модель данных заказчика в БД
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }

        // ФИО
        public string? Name { get; set; }        
        public string? Email { get; set; }                
		public string? Phone { get; set; }              
		public string? Address { get; set; }

        // имя пользователя, под чей УЗ делается заказ
        public string? UserIdentityName {get; set; }
	}
}