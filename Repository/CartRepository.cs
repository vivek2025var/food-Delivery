using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly string _connectionString;

        public CartRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cart>(
                "SELECT * FROM Cart WHERE UserID = @UserID",
                new { UserID = userId }
            );
        }

        public async Task<int> CreateCart(int userId)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Cart (UserID) VALUES (@UserID)";
            return await connection.ExecuteAsync(query, new { UserID = userId });
        }

        public async Task<int> DeleteCart(int userId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(
                "DELETE FROM Cart WHERE UserID = @UserID",
                new { UserID = userId }
            );
        }
    }
}
