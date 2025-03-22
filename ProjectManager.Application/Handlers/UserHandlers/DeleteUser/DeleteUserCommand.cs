using MediatR;
using ProjectManager.Application.Shared;

namespace ProjectManager.Application.Handlers.UserHandlers.DeleteUser
{
    public class DeleteUserCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
