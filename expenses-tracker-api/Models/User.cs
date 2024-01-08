namespace expenses_tracker_api.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string email { get; set; }

        public string? imageUrl { get; set; }

        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }


    }
}
