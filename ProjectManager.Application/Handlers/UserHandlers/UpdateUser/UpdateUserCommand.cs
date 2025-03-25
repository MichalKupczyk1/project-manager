using MediatR;
using ProjectManager.Application.Handlers.UserHandlers.CreateUser;
using ProjectManager.Application.Shared;

namespace ProjectManager.Application.Handlers.UserHandlers.UpdateUser
{
    public class UpdateUserCommand : CreateUserCommand, IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}