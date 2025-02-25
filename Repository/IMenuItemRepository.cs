using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetMenuItems();
        Task<MenuItem> GetMenuItemById(int id);
        Task<int> AddMenuItem(MenuItem menuItem);
        Task<int> UpdateMenuItem(MenuItem menuItem);
        Task<int> DeleteMenuItem(int id);
    }
}
