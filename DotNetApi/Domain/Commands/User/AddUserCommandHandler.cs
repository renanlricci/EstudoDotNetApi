using AutoMapper;
using DotNetApi.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetApi.Domain.Commands.User
{
    public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entities.User>(request);
            await _userRepository.AddAsync(entity);
            return Unit.Value;
        }
    }
}
