using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class MenuItemResponseService : IMenuItemResponseService
    {
        private readonly IMenuItemResponseRepository _menuItemResponseRepository;

        public MenuItemResponseService(IMenuItemResponseRepository menuItemResponseRepository)
        {
            _menuItemResponseRepository = menuItemResponseRepository;
        }

        public Task<IEnumerable<MenuItemResponse>> GetMenuItemsByName(string itemName)
        {
            return _menuItemResponseRepository.GetMenuItemsByName(itemName);
        }
    }
}
