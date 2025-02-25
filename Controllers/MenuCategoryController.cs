using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public MenuCategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetMenuCategories() => Ok(await _menuCategoryService.GetMenuCategories());

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategory>> GetMenuCategory(int id)
        {
            var category = await _menuCategoryService.GetMenuCategoryById(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddMenuCategory(MenuCategory menuCategory)
        {
            await _menuCategoryService.AddMenuCategory(menuCategory);
            return CreatedAtAction(nameof(GetMenuCategory), new { id = menuCategory.MenuCategoryID }, menuCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuCategory(int id, MenuCategory menuCategory)
        {
            if (id != menuCategory.MenuCategoryID) return BadRequest();
            await _menuCategoryService.UpdateMenuCategory(menuCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            await _menuCategoryService.DeleteMenuCategory(id);
            return NoContent();
        }
    }
}
