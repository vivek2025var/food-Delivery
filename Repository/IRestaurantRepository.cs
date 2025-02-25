using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.FoodDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurantById(int resId);
        Task<int> AddRestaurant(Restaurant restaurant);
        Task<int> UpdateRestaurant(Restaurant restaurant);
        Task<int> DeleteRestaurant(int resId);
        Task<IEnumerable<MenuItemResponse>> GetMenuByResId(int resId); // ✅ Fetch Menu by Restaurant ID
    }
}
