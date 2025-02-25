using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int orderId);
        Task<int> PlaceOrder(Order order);
        Task<int> UpdateOrderStatus(int orderId, string orderStatus);
        Task<int> DeleteOrder(int orderId);
    }
}
