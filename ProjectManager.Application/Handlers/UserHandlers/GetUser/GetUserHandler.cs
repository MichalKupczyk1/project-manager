using MediatR;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Application.Handlers.UserHandlers.GetUser
{
    internal class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResult>
    {
        private readonly IUserRepository _userRepository;
        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id, cancellationToken);

            return new GetUserResult() { Email = user?.Email, Login = user?.Login };
        }
    }
}
