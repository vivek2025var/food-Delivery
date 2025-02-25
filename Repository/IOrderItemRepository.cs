using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItems(int orderId);
        Task<int> AddOrderItem(int orderId, int menuItemId, int quantity);
        Task<int> UpdateOrderItem(int orderItemId, int quantity);
        Task<int> RemoveOrderItem(int orderItemId);
    }
}
