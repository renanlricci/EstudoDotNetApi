using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace DotNetApi.Domain.Queries.User
{
    public sealed class GetAllUserQuery : IRequest<IEnumerable<GetAllUserQueryResponse>>
    {
    }
}
