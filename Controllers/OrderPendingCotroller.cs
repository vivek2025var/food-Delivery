using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodDeliveryAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderPendingCotroller : ControllerBase
    {
        private readonly IOrderpendingService _orderService;

        public OrderPendingCotroller(IOrderpendingService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder([FromBody] Order order)
        {
            if (order == null || string.IsNullOrEmpty(order.OrderId.ToString()) || string.IsNullOrEmpty(order.RestaurantId.ToString()))
            {
                return BadRequest("Invalid order details");
            }

            var result = await _orderService.PlaceOrderAsync(order);
            if (!result) return StatusCode(500, "Failed to place order");

            return Ok(new { message = "Order placed successfully" });
        }

        [HttpGet("pending/{restaurantId}")]
        public async Task<IActionResult> GetPendingOrders(string restaurantId)
        {
            var orders = await _orderService.GetPendingOrdersAsync(restaurantId);

            if (orders.Count == 0)
            {
                return NoContent();
            }

            return Ok(orders);
        }

        [HttpPost("mark-notified/{orderId}")]
        public async Task<IActionResult> MarkOrderNotified(string orderId)
        {
            var result = await _orderService.MarkOrderNotifiedAsync(orderId);
            if (!result) return StatusCode(500, "Failed to update order status");

            return Ok(new { message = "Order marked as notified" });
        }
    }
}


