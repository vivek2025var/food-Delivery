namespace FoodDeliveryAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }  // Auto-incrementing ID
        public int OrderID { get; set; }      // Order ID (Foreign Key)
        public int MenuItemID { get; set; }   // Menu Item ID (Foreign Key)
        public int Quantity { get; set; }     // Quantity of the item
    }
}
