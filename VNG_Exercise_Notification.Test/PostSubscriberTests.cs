using Moq;
using SlimMessageBus;
using VNG_Exercise_Notification.Models;
using VNG_Exercise_Notification.Models.Events;
using Xunit;

namespace VNG_Exercise_Notification.Test;
public class PostSubscriberTests
{
    [Fact]
    public async Task OnHandle_ShouldProcessEvent()
    {
        var users = new List<User>()
            {
                new User() {
                    Id = new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE"),
                    Name = "Bach1",
                    FollowerIds = new List<Guid>{new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A03"), new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A04")}
                },
                new User() {
                    Id = new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A03"),
                    Name = "Bach2",
                    FollowerIds = new List<Guid> {new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE") }
                },
                new User() {
                    Id = new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A04"),
                    Name = "Bach3",
                    FollowerIds = new List<Guid> {new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE") }
                }

            };

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
        var subscriber = new Events.EventHandler(users);

        await subscriber.OnHandle(newEvent);
    }
}
