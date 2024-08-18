namespace VNG_Exercise_Notification.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
