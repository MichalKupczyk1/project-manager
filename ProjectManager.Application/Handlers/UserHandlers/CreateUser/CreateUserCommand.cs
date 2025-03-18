using MediatR;
using ProjectManager.Application.Shared;

namespace ProjectManager.Application.Handlers.CreateUser
{
    public class CreateUserCommand : IRequest<CommandResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
