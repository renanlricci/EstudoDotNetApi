using MediatR;

namespace DotNetApi.Domain.Queries.User
{
    public sealed class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
