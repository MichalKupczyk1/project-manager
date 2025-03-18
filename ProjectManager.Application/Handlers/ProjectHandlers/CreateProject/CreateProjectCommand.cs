using MediatR;
using ProjectManager.Application.Shared;

namespace ProjectManager.Application.Handlers.ProjectHandlers.CreateProject
{
    public class CreateProjectCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? OwnerId { get; set; }
    }
}
