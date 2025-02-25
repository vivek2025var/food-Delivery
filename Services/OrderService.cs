using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> GetOrders() => _orderRepository.GetOrders();
        public Task<Order> GetOrderById(int orderId) => _orderRepository.GetOrderById(orderId);
        public Task<int> PlaceOrder(Order order) => _orderRepository.PlaceOrder(order);
        public Task<int> UpdateOrderStatus(int orderId, string orderStatus) => _orderRepository.UpdateOrderStatus(orderId, orderStatus);
        public Task<int> DeleteOrder(int orderId) => _orderRepository.DeleteOrder(orderId);
    }
}
