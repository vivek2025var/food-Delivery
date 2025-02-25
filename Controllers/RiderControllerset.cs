using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers 
{
   
        [ApiController]
        [Route("api/riders")]
        public class RiderSetController : ControllerBase
        {
            private readonly IRiderSetService _riderService;

            public RiderSetController(IRiderSetService riderService)
            {
                _riderService = riderService;
            }

            [HttpGet("nearby")]
            public async Task<IActionResult> GetNearbyRiders([FromQuery] double restaurantLat, [FromQuery] double restaurantLon, [FromQuery] double radiusKm = 5)
            {
                var riders = await _riderService.FindNearbyRidersAsync(restaurantLat, restaurantLon, radiusKm);

                if (riders.Count == 0)
                {
                    return NoContent();
                }

                return Ok(riders);
            }
        }
    }

