using Moq;
using SlimMessageBus;
using VNG_Exercise_Notification.Models.Events;

namespace VNG_Exercise_Notification.Test
{
    public class PostPublisherTests
    {
        [Fact]
        public async Task PublishPostAsync_ShouldPublishEvent()
        {
            var mockMessageBus = new Mock<IMessageBus>();

            var newEvent = new NotificationCreatePostEvent
            {
                Post = new Models.Post
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE"),
                    Content = "User: 8042B6B0-D99C-484A-AF33-0BD9C6AC59FE create new post",
                },
                UserId = new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE"),
            };
            var publibser = mockMessageBus.Object;

           await publibser.Publish(newEvent);

        }
    }
}