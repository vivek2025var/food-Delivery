using FoodDeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderItems(int orderId) => Ok(await _orderItemService.GetOrderItems(orderId));

        [HttpPost("add")]
        public async Task<IActionResult> AddOrderItem(int orderId, int menuItemId, int quantity)
        {
            await _orderItemService.AddOrderItem(orderId, menuItemId, quantity);
            return Ok("Item added to order.");
        }

        [HttpPut("update/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderItemId, int quantity)
        {
            await _orderItemService.UpdateOrderItem(orderItemId, quantity);
            return Ok("Order item updated.");
        }

        [HttpDelete("remove/{orderItemId}")]
        public async Task<IActionResult> RemoveOrderItem(int orderItemId)
        {
            await _orderItemService.RemoveOrderItem(orderItemId);
            return Ok("Order item removed.");
        }
    }
}
