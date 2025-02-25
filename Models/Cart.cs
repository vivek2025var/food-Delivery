namespace FoodDeliveryAPI.Models
{
    public class Cart
    {
        public int CartID { get; set; }  // Auto-incrementing ID
        public int UserID { get; set; }  // User ID (Foreign Key)
    }
}
