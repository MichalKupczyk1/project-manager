using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Domain.Exceptions;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.ProjectHandlers.DeleteProject
{
    internal class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, CommandResult>
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<CommandResult> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _projectRepository.DeleteProject(request.Id, cancellationToken);

            if (!deleted)
                throw new BadRequestException("Failed to delete project with given Id");

            return new CommandResult() { IsSuccess = deleted };
        }
    }
}
