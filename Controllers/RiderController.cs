using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {
        private readonly IRiderService _riderService;

        public RiderController(IRiderService riderService)
        {
            _riderService = riderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rider>>> GetRiders() => Ok(await _riderService.GetRiders());

        [HttpGet("{id}")]
        public async Task<ActionResult<Rider>> GetRider(int id)
        {
            var rider = await _riderService.GetRiderById(id);
            return rider == null ? NotFound() : Ok(rider);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> AddRider(Rider rider)
        {
            await _riderService.AddRider(rider);
            return CreatedAtAction(nameof(GetRider), new { id = rider.RiderID }, rider);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRider(int id, Rider rider)
        {
            if (id != rider.RiderID) return BadRequest();
            await _riderService.UpdateRider(rider);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRider(int id)
        {
            await _riderService.DeleteRider(id);
            return NoContent();
        }
    }
}
