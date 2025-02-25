using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class MenuItemResponseRepository : IMenuItemResponseRepository
    {
        private readonly string _connectionString;

        public MenuItemResponseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<MenuItemResponse>> GetMenuItemsByName(string itemName)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"
                SELECT R.ResName, M.ItemName, M.Price
                FROM MenuItems M
                JOIN Restaurants R ON M.ResID = R.ResID
                WHERE M.ItemName = @ItemName";

            return await connection.QueryAsync<MenuItemResponse>(query, new { ItemName = itemName });
        }
    }
}
