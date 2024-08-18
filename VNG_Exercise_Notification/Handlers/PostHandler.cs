using SlimMessageBus;
using VNG_Exercise_Notification.Models;
using VNG_Exercise_Notification.Models.Commands;
using VNG_Exercise_Notification.Models.Events;

namespace VNG_Exercise_Notification.Handlers
{
    public class PostHandler : MediatR.IRequestHandler<AddPostCommand, Guid>
    {
        private readonly List<User> _users;
        private readonly IServiceProvider _serviceProvider;

        public PostHandler(List<User> users, IServiceProvider serviceProvider)
        {
            _users = users;
            _serviceProvider = serviceProvider;
        }

        public async Task<Guid> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Content = request.Content
            };

            var followerIds = _users.Where(x => x.Id == request.UserId).SelectMany(x => x.FollowerIds).ToList();

            var bus = _serviceProvider.GetRequiredService<IMessageBus>();

            await bus.Publish(new NotificationCreatePostEvent()
            { Post = newPost, UserId = request.UserId, Content = request.Content });

            return newPost.Id;
        }
    }
}
