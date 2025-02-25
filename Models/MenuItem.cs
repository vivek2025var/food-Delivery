namespace FoodDeliveryAPI.Models
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }   // Auto-incrementing ID
        public int MenuCategoryID { get; set; }  // Category ID (Foreign Key)
        public string ItemName { get; set; }  // Menu Item Name
        public int ResID { get; set; }        // Restaurant ID (Foreign Key)
        public decimal Price { get; set; }    // Item Price
    }
}
