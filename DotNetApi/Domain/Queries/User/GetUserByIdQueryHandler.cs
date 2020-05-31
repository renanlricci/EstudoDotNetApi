using AutoMapper;
using DotNetApi.Domain.Interfaces.Repositories;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetApi.Domain.Queries.User
{
    public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetAsync(ObjectId.Parse(request.Id)); ;
            return _mapper.Map<GetUserByIdQueryResponse>(response);
        }
    }
}
