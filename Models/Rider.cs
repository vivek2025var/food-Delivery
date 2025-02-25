namespace FoodDeliveryAPI.Models
{
    public class Rider
    {
        public int RiderID { get; set; }             // Auto-incrementing ID
        public string Name { get; set; }             // Rider's name
        public string PhoneNumber { get; set; }      // Contact number
        public decimal CurrentLatitude { get; set; } // Rider's current latitude
        public decimal CurrentLongitude { get; set; } // Rider's current longitude
        public bool IsAvailable { get; set; } = true; // Availability status (default: true)
        public int? LastAssignedOrderID { get; set; } // Last order assigned (optional)
        public DateTime? LastAssignedTime { get; set; } // Last assigned time (optional)
    }

}
