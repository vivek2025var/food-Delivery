using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Order>("SELECT * FROM Orders");
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Order>(
                "SELECT * FROM Orders WHERE OrderId = @OrderId", new { OrderId = orderId }
            );
        }

        public async Task<int> PlaceOrder(Order order)
        {
            using var connection = new SqlConnection(_connectionString);
            
            
            string query = "INSERT INTO Orders (UserID, ResID, TotalAmount, OrderStatus, PaymentStatus, Longitude, Latitude) " +
                           "VALUES (@UserID, @ResID, @TotalAmount, @OrderStatus, @PaymentStatus, @Longitude, @Latitude)";
            
         var xx =   await connection.ExecuteAsync(query, order);
            string sql = $"EXEC sp_UpdateOrderTotal @OrderId={xx}";

            await connection.ExecuteAsync(query);
            return xx;

        }

        public async Task<int> UpdateOrderStatus(int orderId, string orderStatus)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "UPDATE Orders SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId",
                new { OrderStatus = orderStatus, OrderId = orderId }
            );
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "DELETE FROM Orders WHERE OrderId = @OrderId",
                new { OrderId = orderId }
            );
        }
    }
}
