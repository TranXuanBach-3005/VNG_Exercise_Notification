using MediatR;
using Microsoft.AspNetCore.Mvc;
using VNG_Exercise_Notification.Models;
using VNG_Exercise_Notification.Models.Commands;

namespace VNG_Exercise_Notification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly ISender _sender;
        private readonly List<User> _users;


        public PostController(ILogger<PostController> logger, ISender sender, List<User> users)
        {
            _logger = logger;
            _sender = sender;
            _users = users;
        }

        [HttpGet("users")]
        public IActionResult GetAllUser()
        {
            var users = _users.ToList();
            return Ok(users);
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePost(AddPostCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(result);
        }
    }
}
