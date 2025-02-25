using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class RiderRepository : IRiderRepository
    {
        private readonly string _connectionString;

        public RiderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Rider>> GetRiders()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Rider>("SELECT * FROM Riders");
        }

        public async Task<Rider> GetRiderById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Rider>("SELECT * FROM Riders WHERE RiderID = @Id", new { Id = id });
        }

        public async Task<int> AddRider(Rider rider)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Riders (Name, PhoneNumber, CurrentLatitude, CurrentLongitude, IsAvailable, LastAssignedOrderID, LastAssignedTime) " +
                         "VALUES (@Name, @PhoneNumber, @CurrentLatitude, @CurrentLongitude, @IsAvailable, @LastAssignedOrderID, @LastAssignedTime)";
            return await connection.ExecuteAsync(sql, rider);
        }

        public async Task<int> UpdateRider(Rider rider)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE Riders SET Name = @Name, PhoneNumber = @PhoneNumber, CurrentLatitude = @CurrentLatitude, " +
                         "CurrentLongitude = @CurrentLongitude, IsAvailable = @IsAvailable, LastAssignedOrderID = @LastAssignedOrderID, " +
                         "LastAssignedTime = @LastAssignedTime WHERE RiderID = @RiderID";
            return await connection.ExecuteAsync(sql, rider);
        }

        public async Task<int> DeleteRider(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("DELETE FROM Riders WHERE RiderID = @Id", new { Id = id });
        }
    }
}
