using MediatR;

namespace VNG_Exercise_Notification.Models.Commands
{
    public class AddPostCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; } 
        public string Content { get; set; }
    }
}
