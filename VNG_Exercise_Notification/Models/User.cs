namespace VNG_Exercise_Notification.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid>? FollowerIds { get; set; }
    }
}
