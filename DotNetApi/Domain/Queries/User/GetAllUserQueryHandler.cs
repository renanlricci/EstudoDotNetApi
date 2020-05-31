using AutoMapper;
using DotNetApi.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetApi.Domain.Queries.User
{
    public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<GetAllUserQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllUserQueryResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetAsync();
            return _mapper.Map<IEnumerable<GetAllUserQueryResponse>>(response);
        }
    }
}
