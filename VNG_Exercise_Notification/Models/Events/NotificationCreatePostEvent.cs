using VNG_Exercise_Notification.Models.Commands;

namespace VNG_Exercise_Notification.Models.Events
{
    public class NotificationCreatePostEvent : AddPostCommand
    {
        public Post Post { get; set; }
    }
}
