using FoodDeliveryAPI.Models;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserId(int userId);
        Task<int> CreateCart(int userId);
        Task<int> DeleteCart(int userId);
    }
}
