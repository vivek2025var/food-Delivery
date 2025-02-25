namespace FoodDeliveryAPI.Models
{
    namespace FoodDeliveryAPI.Models
    {
        public class Restaurant
            {
                public int ResID { get; set; }             // Auto-incrementing ID
                public string ResName { get; set; }        // Restaurant name
                public string EmailID { get; set; }        // Unique email
                public string PhoneNo { get; set; }        // Contact number
                public string License { get; set; }        // Unique License Number
                public decimal Longitude { get; set; }     // Location Longitude
                public decimal Latitude { get; set; }      // Location Latitude
                public int OrderTime { get; set; }    //delivery time 
        }
    }
}
