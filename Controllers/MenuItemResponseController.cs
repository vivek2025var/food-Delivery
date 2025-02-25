using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/menuitems")]
    [ApiController]
    public class MenuItemResponseController : ControllerBase
    {
        private readonly IMenuItemResponseService _menuItemResponseService;

        public MenuItemResponseController(IMenuItemResponseService menuItemResponseService)
        {
            _menuItemResponseService = menuItemResponseService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMenuItemsByName([FromQuery] string itemName)
        {
            var menuItems = await _menuItemResponseService.GetMenuItemsByName(itemName);
            return menuItems != null ? Ok(menuItems) : NotFound("No items found.");
        }
    }
}
