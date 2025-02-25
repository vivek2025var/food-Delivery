using FoodDeliveryAPI.Models;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task<int> CreateCart(int userId);
        Task<int> DeleteCart(int userId);
    }
}
