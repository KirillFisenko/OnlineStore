using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductRepository productRepository = new ProductRepository();

        public string Index(int id)
        {
            var result = productRepository.TryGetById(id);
            return result == null ? $"Продукта с id {id} не существует" : $"{result}\n{result.Description}";
        }
    }
}
