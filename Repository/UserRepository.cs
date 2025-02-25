using Microsoft.Data.SqlClient;  // Explicitly specify the correct namespace
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using FoodDeliveryAPI.Models;
using Microsoft.Extensions.Configuration;

namespace FoodDeliveryAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User> GetUserById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE UserId = @Id", new { Id = id });
        }

        public async Task<int> RegisterUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Users (Name, Email, PasswordHash, PhoneNumber, Latitude, Longitude) VALUES (@Name, @Email, @PasswordHash, @PhoneNumber, @Latitude, @Longitude)";
            return await connection.ExecuteAsync(sql, user);
        }

        public async Task<int> UpdateUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE Users SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash, PhoneNumber = @PhoneNumber, Latitude = @Latitude, Longitude = @Longitude WHERE UserId = @UserId";
            return await connection.ExecuteAsync(sql, user);
        }

        public async Task<int> DeleteUser(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("DELETE FROM Users WHERE UserId = @Id", new { Id = id });
        }
    }
}
