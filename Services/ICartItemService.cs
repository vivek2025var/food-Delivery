using FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetCartItems(int cartId);
        Task<int> AddCartItem(int cartId, int menuItemId, int quantity);
        Task<int> UpdateCartItem(int cartItemId, int quantity);
        Task<int> RemoveCartItem(int cartItemId);
        Task<int> ClearCart(int cartId);
    }
}
