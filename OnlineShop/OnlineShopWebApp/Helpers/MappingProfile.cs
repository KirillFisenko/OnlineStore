using AutoMapper;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
