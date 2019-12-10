using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Comments;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Name of this method is important because we will invoke this from the client.
        public async Task SendComment(Create.Command command)
        {
            var username = Context.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            command.Username = username;

            var comment = await _mediator.Send(command);

            await Clients.All.SendAsync("ReceiveComment", comment);
        }
    }
}