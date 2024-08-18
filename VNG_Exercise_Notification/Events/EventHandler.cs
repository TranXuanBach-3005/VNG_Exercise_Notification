using SlimMessageBus;
using VNG_Exercise_Notification.Models;
using VNG_Exercise_Notification.Models.Events;

namespace VNG_Exercise_Notification.Events
{
    public class EventHandler : IConsumer<NotificationCreatePostEvent>
    {
        private readonly List<User> _users;

        public EventHandler(List<User> users)
        {
            _users = users;
        }

        public async Task OnHandle(NotificationCreatePostEvent message)
        {
            var user = _users.FirstOrDefault(x => x.Id == message.UserId) ?? throw new Exception("Publiser not found");
            var followerIds = user.FollowerIds;

            if (followerIds is null || followerIds.Count == 0)
                throw new Exception("Not found any Subribers");

            var followers = _users.Where(x => followerIds.Contains(x.Id));
            if (!followers.Any())
                throw new Exception("Not found any Subribers");

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Notification System:");
            Console.WriteLine("Author:{0}", user.Name);
            Console.WriteLine("Content:{0}", message.Content);
            foreach (var follower in followers)
                Console.WriteLine("Notify for follower: userId={0}, userName={1}", follower.Id, follower.Name);

            await Task.CompletedTask;
        }
    }
}
