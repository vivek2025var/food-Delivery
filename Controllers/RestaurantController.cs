using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants() => Ok(await _restaurantService.GetAllRestaurants());

        [HttpGet("{resId}")]
        public async Task<IActionResult> GetRestaurantById(int resId) => Ok(await _restaurantService.GetRestaurantById(resId));

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant) => Ok(await _restaurantService.AddRestaurant(restaurant));

        [HttpPut("{resId}")]
        public async Task<IActionResult> UpdateRestaurant(Restaurant restaurant) => Ok(await _restaurantService.UpdateRestaurant(restaurant));

        [HttpDelete("{resId}")]
        public async Task<IActionResult> DeleteRestaurant(int resId) => Ok(await _restaurantService.DeleteRestaurant(resId));

        [HttpGet("{resId}/menu")]
        public async Task<IActionResult> GetMenuByResId(int resId) => Ok(await _restaurantService.GetMenuByResId(resId));
    }
}
