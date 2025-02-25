using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Services
{
    public interface IOrderpendingService
    {
        Task<bool> PlaceOrderAsync(Order order);
        Task<List<Order>> GetPendingOrdersAsync(string restaurantId);
        Task<bool> MarkOrderNotifiedAsync(string orderId);
    }
}


