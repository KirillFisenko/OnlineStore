using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePaths = product.Images.Select(x => x.Url).ToArray()
            };
        }

        public static Product ToProduct(this AddProductViewModel product, List<string> imagesPaths)
        {
            return new Product
            {                
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Images = ToImages(imagesPaths)
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                User = ToUserDeliveryInfoViewModel(order.User),
                Items = ToCartItemViewModels(order.Items),
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatusViewModel)(int)order.Status
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo deliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = deliveryInfo.Name,
                Email = deliveryInfo.Email,
                Phone = deliveryInfo.Phone,
                Address = deliveryInfo.Address
            };
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address
            };
        }

        public static EditUserViewModel ToEditUserViewModel(this User user)
        {
            return new EditUserViewModel
            {
                UserName = user.UserName,
                Phone = user.PhoneNumber
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Phone = user.PhoneNumber
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }

        private static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartItems)
        {
            var catrItemsViewModels = new List<CartItemViewModel>();
            foreach (var cartItem in cartItems)
            {
                var catrItemsViewModel = new CartItemViewModel
                {
                    Id = cartItem.Id,
                    Quantity = cartItem.Quantity,
                    Product = ToProductViewModel(cartItem.Product)
                };
                catrItemsViewModels.Add(catrItemsViewModel);
            }
            return catrItemsViewModels;
        }
    }
}