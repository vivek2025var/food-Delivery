using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IMenuCategoryRepository
    {
        Task<IEnumerable<MenuCategory>> GetMenuCategories();
        Task<MenuCategory> GetMenuCategoryById(int id);
        Task<int> AddMenuCategory(MenuCategory menuCategory);
        Task<int> UpdateMenuCategory(MenuCategory menuCategory);
        Task<int> DeleteMenuCategory(int id);
    }
}
