using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public interface IMenuItemResponseService
    {
        Task<IEnumerable<MenuItemResponse>> GetMenuItemsByName(string itemName);
    }
}
