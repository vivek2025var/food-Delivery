using Dapper;
using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Models.FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly string _connectionString;

        public RestaurantRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Restaurant>("SELECT * FROM Restaurants");
        }

        public async Task<Restaurant> GetRestaurantById(int resId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Restaurant>(
                "SELECT * FROM Restaurants WHERE ResID = @ResID", new { ResID = resId }
            );
        }

        public async Task<int> AddRestaurant(Restaurant restaurant)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Restaurants (ResName, EmailID, PhoneNo, License, Longitude, Latitude, OrderTime) " +
                           "VALUES (@ResName, @EmailID, @PhoneNo, @License, @Longitude, @Latitude, @OrderTime)";
            return await connection.ExecuteAsync(query, restaurant);
        }

        public async Task<int> UpdateRestaurant(Restaurant restaurant)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "UPDATE Restaurants SET ResName = @ResName, EmailID = @EmailID, PhoneNo = @PhoneNo, License = @License, " +
                "Longitude = @Longitude, Latitude = @Latitude, OrderTime = @OrderTime WHERE ResID = @ResID",
                restaurant
            );
        }

        public async Task<int> DeleteRestaurant(int resId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("DELETE FROM Restaurants WHERE ResID = @ResID", new { ResID = resId });
        }

        public async Task<IEnumerable<MenuItemResponse>> GetMenuByResId(int resId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<MenuItemResponse>(
                "SELECT ItemName, Price FROM MenuItems WHERE ResID = @ResID",
                new { ResID = resId }
            );
        }
    }
}
