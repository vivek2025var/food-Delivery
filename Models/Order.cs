namespace FoodDeliveryAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }         // Auto-incrementing ID
        public int UserID { get; set; }         // User who placed the order
        public int ResID { get; set; }          // Restaurant ID
        public decimal TotalAmount { get; set; } // Total cost of the order
        public string OrderStatus { get; set; } = "Pending";  // Order status
        public string PaymentStatus { get; set; } = "Unpaid"; // Payment status
        public decimal Longitude { get; set; }   // Delivery longitude
        public decimal Latitude { get; set; }    // Delivery latitude
        public int RestaurantId { get; set; }
    }
}
