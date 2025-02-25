using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Task<IEnumerable<Restaurant>> GetAllRestaurants() => _restaurantRepository.GetAllRestaurants();
        public Task<Restaurant> GetRestaurantById(int resId) => _restaurantRepository.GetRestaurantById(resId);
        public Task<int> AddRestaurant(Restaurant restaurant) => _restaurantRepository.AddRestaurant(restaurant);
        public Task<int> UpdateRestaurant(Restaurant restaurant) => _restaurantRepository.UpdateRestaurant(restaurant);
        public Task<int> DeleteRestaurant(int resId) => _restaurantRepository.DeleteRestaurant(resId);
        public Task<IEnumerable<MenuItemResponse>> GetMenuByResId(int resId) => _restaurantRepository.GetMenuByResId(resId);
    }
}
