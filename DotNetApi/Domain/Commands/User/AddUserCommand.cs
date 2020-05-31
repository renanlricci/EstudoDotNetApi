using MediatR;

namespace DotNetApi.Domain.Commands.User
{
    public sealed class AddUserCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
