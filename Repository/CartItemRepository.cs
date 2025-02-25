using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly string _connectionString;

        public CartItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(int cartId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<CartItem>(
                "SELECT * FROM CartItems WHERE CartID = @CartID",
                new { CartID = cartId }
            );
        }

        public async Task<int> AddCartItem(int cartId, int menuItemId, int quantity)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO CartItems (CartID, MenuItemID, Quantity) VALUES (@CartID, @MenuItemID, @Quantity)";
            return await connection.ExecuteAsync(query, new { CartID = cartId, MenuItemID = menuItemId, Quantity = quantity });
        }

        public async Task<int> UpdateCartItem(int cartItemId, int quantity)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "UPDATE CartItems SET Quantity = @Quantity WHERE CartItemID = @CartItemID",
                new { Quantity = quantity, CartItemID = cartItemId }
            );
        }

        public async Task<int> RemoveCartItem(int cartItemId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "DELETE FROM CartItems WHERE CartItemID = @CartItemID",
                new { CartItemID = cartItemId }
            );
        }

        public async Task<int> ClearCart(int cartId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "DELETE FROM CartItems WHERE CartID = @CartID",
                new { CartID = cartId }
            );
        }
    }
}
