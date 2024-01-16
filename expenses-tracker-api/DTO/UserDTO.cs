using expenses_tracker_api.Models;

namespace expenses_tracker_api.DTO
{
    public class UserDTO
    {
        public string? AmazonUsername { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? MainCurrency { get; set; }
         
    }
}
