using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems() => Ok(await _menuItemService.GetMenuItems());

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            return menuItem == null ? NotFound() : Ok(menuItem);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddMenuItem(MenuItem menuItem)
        {
            await _menuItemService.AddMenuItem(menuItem);
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemID }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemID) return BadRequest();
            await _menuItemService.UpdateMenuItem(menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItem(id);
            return NoContent();
        }
    }
}
