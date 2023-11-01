namespace OnlineShopWebApp.Models
{
    // модель для редактирования данных пользователя самим пользователем
    public class EditUserByUserViewModel
    {
        // номер телефона
        public string? PhoneNumber { get; set; }

        // подтвержден ли Email
        public bool EmailConfirmed { get; set; }

        // имя
        public string? FirstName { get; set; }

        // адрес
        public string? Address { get; set; }

        // ссылка на аватар
        public string? AvatarUrl { get; set; }

        // загружаемый файл аватара
        public IFormFile? UploadedFile { get; set; }
    }
}
