namespace FoodDeliveryAPI.Models
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }  // Auto-incrementing ID
        public string CategoryName { get; set; } // Category Name (e.g., "Appetizers")
        public int ResID { get; set; }           // Restaurant ID (Foreign Key)
    }
}
