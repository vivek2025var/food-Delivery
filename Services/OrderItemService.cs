using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public Task<IEnumerable<OrderItem>> GetOrderItems(int orderId) => _orderItemRepository.GetOrderItems(orderId);
        public Task<int> AddOrderItem(int orderId, int menuItemId, int quantity) => _orderItemRepository.AddOrderItem(orderId, menuItemId, quantity);
        public Task<int> UpdateOrderItem(int orderItemId, int quantity) => _orderItemRepository.UpdateOrderItem(orderItemId, quantity);
        public Task<int> RemoveOrderItem(int orderItemId) => _orderItemRepository.RemoveOrderItem(orderItemId);
    }
}
