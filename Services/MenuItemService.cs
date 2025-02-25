using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public Task<IEnumerable<MenuItem>> GetMenuItems() => _menuItemRepository.GetMenuItems();
        public Task<MenuItem> GetMenuItemById(int id) => _menuItemRepository.GetMenuItemById(id);
        public Task<int> AddMenuItem(MenuItem menuItem) => _menuItemRepository.AddMenuItem(menuItem);
        public Task<int> UpdateMenuItem(MenuItem menuItem) => _menuItemRepository.UpdateMenuItem(menuItem);
        public Task<int> DeleteMenuItem(int id) => _menuItemRepository.DeleteMenuItem(id);
    }
}
