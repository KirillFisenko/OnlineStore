using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OnlineShopWebApp.Helpers
{
    // для отображения читаемого значения перечисления
    public class EnumHelper
    {
        public static string? GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
        }
    }
}