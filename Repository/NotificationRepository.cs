using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<int> LogNotification(int userId, string message);
    }

    public class NotificationRepository : INotificationRepository
    {
        private readonly string _connectionString; // ✅ only one definition

        public NotificationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT UserId, Name, Email FROM Users"; // adjust table/columns
            return await connection.QueryAsync<AppUser>(query);
        }

        public async Task<int> LogNotification(int userId, string message)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"INSERT INTO Notifications (UserId, Message, SentAt) 
                             VALUES (@UserId, @Message, GETDATE())";
            return await connection.ExecuteAsync(query, new { UserId = userId, Message = message });
        }
    }
}
