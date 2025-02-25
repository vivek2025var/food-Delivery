using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<Cart> GetCartByUserId(int userId) => _cartRepository.GetCartByUserId(userId);
        public Task<int> CreateCart(int userId) => _cartRepository.CreateCart(userId);
        public Task<int> DeleteCart(int userId) => _cartRepository.DeleteCart(userId);
    }
}
