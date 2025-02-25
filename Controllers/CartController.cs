using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // ✅ Get User's Cart
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _cartService.GetCartByUserId(userId);
            return cart != null ? Ok(cart) : NotFound("Cart not found.");
        }

        // ✅ Create Cart for a User
        [HttpPost("create")]
        public async Task<IActionResult> CreateCart(int userId)
        {
            await _cartService.CreateCart(userId);
            return Ok("Cart created successfully.");
        }

        // ✅ Delete Cart for a User
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteCart(int userId)
        {
            await _cartService.DeleteCart(userId);
            return Ok("Cart deleted successfully.");
        }
    }
}
