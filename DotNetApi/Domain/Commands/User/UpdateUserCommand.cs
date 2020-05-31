using MediatR;

namespace DotNetApi.Domain.Commands.User
{
    public sealed class UpdateUserCommand : IRequest<Unit>
    {
        public void SetId(string id) => Id = id;
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
