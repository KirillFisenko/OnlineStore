using AutoMapper;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, EditUserViewModel>().ReverseMap();
            CreateMap<User, EditUserByUserViewModel>().ReverseMap();
			CreateMap<UserDeliveryInfo, UserDeliveryInfoViewModel>().ReverseMap();
			
			CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, EditProductViewModel>().ReverseMap();
            CreateMap<Product, AddProductViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();          

            CreateMap<Cart, CartViewModel>().ReverseMap();
			CreateMap<CartItem, CartItemViewModel>().ReverseMap();

			CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
