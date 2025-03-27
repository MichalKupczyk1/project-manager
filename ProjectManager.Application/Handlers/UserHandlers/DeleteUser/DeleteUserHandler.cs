using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.UserHandlers.DeleteUser
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userDeleted = await _userRepository.DeleteUser(request.Id, cancellationToken);

            return new CommandResult() { IsSuccess = userDeleted };
        }
    }
}
