using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public Task<IEnumerable<CartItem>> GetCartItems(int cartId) => _cartItemRepository.GetCartItems(cartId);
        public Task<int> AddCartItem(int cartId, int menuItemId, int quantity) => _cartItemRepository.AddCartItem(cartId, menuItemId, quantity);
        public Task<int> UpdateCartItem(int cartItemId, int quantity) => _cartItemRepository.UpdateCartItem(cartItemId, quantity);
        public Task<int> RemoveCartItem(int cartItemId) => _cartItemRepository.RemoveCartItem(cartItemId);
        public Task<int> ClearCart(int cartId) => _cartItemRepository.ClearCart(cartId);
    }
}
