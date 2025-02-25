using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders() => Ok(await _orderService.GetOrders());

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId) => Ok(await _orderService.GetOrderById(orderId));

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            await _orderService.PlaceOrder(order);
            return Ok("Order placed successfully.");
        }

        [HttpPut("update/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, string orderStatus)
        {
            await _orderService.UpdateOrderStatus(orderId, orderStatus);
            return Ok("Order status updated.");
        }

        [HttpDelete("cancel/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return Ok("Order cancelled successfully.");
        }
    }
}
