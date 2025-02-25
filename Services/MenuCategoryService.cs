using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuCategoryService(IMenuCategoryRepository menuCategoryRepository)
        {
            _menuCategoryRepository = menuCategoryRepository;
        }

        public Task<IEnumerable<MenuCategory>> GetMenuCategories() => _menuCategoryRepository.GetMenuCategories();
        public Task<MenuCategory> GetMenuCategoryById(int id) => _menuCategoryRepository.GetMenuCategoryById(id);
        public Task<int> AddMenuCategory(MenuCategory menuCategory) => _menuCategoryRepository.AddMenuCategory(menuCategory);
        public Task<int> UpdateMenuCategory(MenuCategory menuCategory) => _menuCategoryRepository.UpdateMenuCategory(menuCategory);
        public Task<int> DeleteMenuCategory(int id) => _menuCategoryRepository.DeleteMenuCategory(id);
    }
}
