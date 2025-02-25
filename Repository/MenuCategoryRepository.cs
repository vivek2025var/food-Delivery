using Dapper;
using FoodDeliveryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly string _connectionString;

        public MenuCategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<MenuCategory>> GetMenuCategories()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<MenuCategory>("SELECT * FROM MenuCategories");
        }

        public async Task<MenuCategory> GetMenuCategoryById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<MenuCategory>("SELECT * FROM MenuCategories WHERE MenuCategoryID = @Id", new { Id = id });
        }

        public async Task<int> AddMenuCategory(MenuCategory menuCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO MenuCategories (CategoryName, ResID) VALUES (@CategoryName, @ResID)";
            return await connection.ExecuteAsync(sql, menuCategory);
        }

        public async Task<int> UpdateMenuCategory(MenuCategory menuCategory)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE MenuCategories SET CategoryName = @CategoryName, ResID = @ResID WHERE MenuCategoryID = @MenuCategoryID";
            return await connection.ExecuteAsync(sql, menuCategory);
        }

        public async Task<int> DeleteMenuCategory(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("DELETE FROM MenuCategories WHERE MenuCategoryID = @Id", new { Id = id });
        }
    }
}
