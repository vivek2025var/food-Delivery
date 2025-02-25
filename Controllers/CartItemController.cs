using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/cartitems")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartItems(int cartId) => Ok(await _cartItemService.GetCartItems(cartId));

        [HttpPost("add")]
        public async Task<IActionResult> AddCartItem(int cartId, int menuItemId, int quantity)
        {
            await _cartItemService.AddCartItem(cartId, menuItemId, quantity);
            return Ok("Item added to cart.");
        }

        [HttpPut("update/{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, int quantity)
        {
            await _cartItemService.UpdateCartItem(cartItemId, quantity);
            return Ok("Cart item updated.");
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            await _cartItemService.RemoveCartItem(cartItemId);
            return Ok("Cart item removed.");
        }

        [HttpDelete("clear/{cartId}")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            await _cartItemService.ClearCart(cartId);
            return Ok("Cart cleared.");
        }
    }
}
