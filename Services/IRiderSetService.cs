using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Services
{
    public interface IRiderSetService
    {
        Task<List<Rider>> FindNearbyRidersAsync(double restaurantLat, double restaurantLon, double radiusKm);
    }
}
