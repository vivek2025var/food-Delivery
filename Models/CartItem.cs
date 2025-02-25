namespace FoodDeliveryAPI.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }  // Auto-incrementing ID
        public int CartID { get; set; }      // Cart ID (Foreign Key)
        public int MenuItemID { get; set; }  // Menu Item ID (Foreign Key)
        public int Quantity { get; set; }    // Quantity of the item
    }
}
