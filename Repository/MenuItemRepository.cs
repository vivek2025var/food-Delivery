using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly string _connectionString;

        public MenuItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<MenuItem>("SELECT * FROM MenuItems");
        }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<MenuItem>("SELECT * FROM MenuItems WHERE MenuItemID = @Id", new { Id = id });
        }

        public async Task<int> AddMenuItem(MenuItem menuItem)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO MenuItems (MenuCategoryID, ItemName, ResID, Price) VALUES (@MenuCategoryID, @ItemName, @ResID, @Price)";
            return await connection.ExecuteAsync(sql, menuItem);
        }

        public async Task<int> UpdateMenuItem(MenuItem menuItem)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE MenuItems SET MenuCategoryID = @MenuCategoryID, ItemName = @ItemName, ResID = @ResID, Price = @Price WHERE MenuItemID = @MenuItemID";
            return await connection.ExecuteAsync(sql, menuItem);
        }

        public async Task<int> DeleteMenuItem(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("DELETE FROM MenuItems WHERE MenuItemID = @Id", new { Id = id });
        }
    }
}
