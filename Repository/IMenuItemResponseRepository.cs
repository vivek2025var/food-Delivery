using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IMenuItemResponseRepository
    {
        Task<IEnumerable<MenuItemResponse>> GetMenuItemsByName(string itemName);
    }
}
