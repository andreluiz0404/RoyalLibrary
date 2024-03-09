namespace RoyalLibrary.Models
{
    public class Book
    {
        public int book_id { get; set; }

        public required string title { get; init; }

        public required string first_name { get; init; }

        public required string last_name { get; init; }

        public int total_copies { get; set; } = 0;

        public int copies_in_use { get; set; } = 0;

        public string? type { get; set; }

        public string? isbn { get; set; }

        public string? category { get; }
    }
}
