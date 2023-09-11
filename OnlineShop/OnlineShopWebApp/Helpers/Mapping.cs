using OnlineShop.Db.Models;
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
            Date = order.Date,
            Time = order.Time,
            Items = order.Items,
            Status = order.Status,
            User = order.User            
        };
    }
}
