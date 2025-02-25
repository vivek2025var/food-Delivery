using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using FoodDeliveryAPI.Services;

namespace FoodDeliveryAPI.Services
{
    public class OrderPendingService : IOrderpendingService
    {
        private readonly IOrderpendingService _orderRepository;

        public OrderPendingService(IOrderpendingService orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            return await _orderRepository.PlaceOrderAsync(order);
        }

        public async Task<List<Order>> GetPendingOrdersAsync(string restaurantId)
        {
            return await _orderRepository.GetPendingOrdersAsync(restaurantId);
        }

        public async Task<bool> MarkOrderNotifiedAsync(string orderId)
        {
            return await _orderRepository.MarkOrderNotifiedAsync(orderId);
        }
    }
}

