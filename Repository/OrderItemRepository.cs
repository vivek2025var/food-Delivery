using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly string _connectionString;

        public OrderItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<OrderItem>> GetOrderItems(int orderId)
            {
                using var connection = new SqlConnection(_connectionString);
                return await connection.QueryAsync<OrderItem>(
                    "SELECT * FROM OrderItems WHERE OrderID = @OrderID",
                    new { OrderID = orderId }
                );
            }
        

        public async Task<int> AddOrderItem(int orderId, int menuItemId, int quantity)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO OrderItems (OrderID, MenuItemID, Quantity) VALUES (@OrderID, @MenuItemID, @Quantity)";
            return await connection.ExecuteAsync(query, new { OrderID = orderId, MenuItemID = menuItemId, Quantity = quantity });
        }

        public async Task<int> UpdateOrderItem(int orderItemId, int quantity)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "UPDATE OrderItems SET Quantity = @Quantity WHERE OrderItemId = @OrderItemId",
                new { Quantity = quantity, OrderItemId = orderItemId }
            );
        }

        public async Task<int> RemoveOrderItem(int orderItemId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "DELETE FROM OrderItems WHERE OrderItemId = @OrderItemId",
                new { OrderItemId = orderItemId }
            );
        }
    }
}
