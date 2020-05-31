using MediatR;

namespace DotNetApi.Domain.Commands.User
{
    public sealed class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(string id) => Id = id;

        public string Id { get; }
    }
}
