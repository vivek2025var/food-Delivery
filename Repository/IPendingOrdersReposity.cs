using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FoodDeliveryAPI.Repository
{
    public interface IPendingOrdersReposity
    {
        Task<bool> PlaceOrderAsync(Order order);
        Task<List<Order>> GetPendingOrdersAsync(string restaurantId);
        Task<bool> MarkOrderNotifiedAsync(string orderId);
    }
}

