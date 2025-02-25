using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FoodDeliveryAPI.Repository
{
    public class PendingOrdersReposity
    {
        private readonly string _connectionString;

        public PendingOrdersReposity(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Orders (OrderId, RestaurantId, Status) VALUES (@OrderId, @RestaurantId, 'Pending')";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@RestaurantId", order.RestaurantId);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        [Obsolete]
        public async Task<List<Order>> GetPendingOrdersAsync(string restaurantId)
        {
            List<Order> pendingOrders = new();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "SELECT OrderId, RestaurantId FROM Orders WHERE RestaurantId = @RestaurantId AND Status = 'Pending'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RestaurantId", restaurantId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            pendingOrders.Add(new Order
                            {
                                OrderId = 0,
                                RestaurantId = 0,
                                OrderStatus = "Pending"
                            });
                        }
                    }
                }
            }

            return pendingOrders;
        }

        public async Task<bool> MarkOrderNotifiedAsync(string orderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "UPDATE Orders SET Status = 'Notified' WHERE OrderId = @OrderId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }
    }
}





