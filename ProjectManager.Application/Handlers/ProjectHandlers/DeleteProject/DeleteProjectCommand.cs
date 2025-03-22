using MediatR;
using ProjectManager.Application.Shared;

namespace ProjectManager.Application.Handlers.ProjectHandlers.DeleteProject
{
    public class DeleteProjectCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
