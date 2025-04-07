using AutoMapper;
using MediatR;
using ProjectManager.Domain.Exceptions;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.UserHandlers.GetUser
{
    internal class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id, cancellationToken);

            if (user == null)
                throw new BadRequestException("User with given Id not found");

            return _mapper.Map<GetUserResult>(user);
        }
    }
}
