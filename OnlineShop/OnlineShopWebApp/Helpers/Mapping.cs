using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public static Product ToProductDb(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModel(cart.Items)
            };
        }

        private static List<CartItemViewModel> ToCartItemViewModel(List<CartItem> cartItems)
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

        private static List<CartItem> ToCartItemDb(List<CartItemViewModel> cartItems)
        {
            var catrItems = new List<CartItem>();
            foreach (var cartItem in cartItems)
            {
                var catrItemsViewModel = new CartItem
                {
                    Id = cartItem.Id,
                    Quantity = cartItem.Quantity,
                    Product = ToProductDb(cartItem.Product)
                };
                catrItems.Add(catrItemsViewModel);
            }
            return catrItems;
        }

        public static Role ToRoleDb(RoleViewModel role)
        {
            return new Role
            {
                Name = role.Name
            };
        }

        public static RoleViewModel ToRoleViewModel(Role role)
        {
            return new RoleViewModel
            {
                Name = role.Name
            };
        }

        public static OrderStatusesViewModel ToOrderStatusesViewModel(OrderStatuses status)
        {
            return new OrderStatusesViewModel
            {
               
            };
        }

        public static OrderStatuses ToOrderStatusesDb(OrderStatusesViewModel status)
        {
            return new OrderStatuses
            {

            };
        }

        public static User ToUserDb(UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Role = ToRoleDb(user.Role)
            };
        }

        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Role = ToRoleViewModel(user.Role)
            };
        }
        public static EditUser ToEditUserDb(EditUserViewModel user)
        {
            return new EditUser
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo user)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address
            };
        }

        public static UserDeliveryInfo ToUserDeliveryInfoDb(UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address
            };
        }

        public static List<OrderViewModel> ToOrderViewModels(List<Order> orders)
        {
            var ordersViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModels.Add(ToOrderViewModel(order));
            }
            return ordersViewModels;
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                User = ToUserDeliveryInfoViewModel(order.User),
                Items = ToCartItemViewModel(order.Items),
                Amount = order.Amount,
                Date = order.Date,
                Time = order.Time,
                Status = ToOrderStatusesViewModel(order.Status)
            };
        }

        public static Order ToOrderDb(OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                User = ToUserDeliveryInfoDb(order.User),
                Items = ToCartItemDb(order.Items),
                Amount = order.Amount,
                Date = order.Date,
                Time = order.Time,
                Status = ToOrderStatusesDb(order.Status)
            };
        }
    }
}