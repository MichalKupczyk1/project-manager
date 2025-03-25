using MediatR;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Application.Handlers.ProjectHandlers.GetProject
{
    internal class GetProjectHandler : IRequestHandler<GetProjectQuery, GetProjectResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;

        public GetProjectHandler(IUserRepository userRepository, IProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        public async Task<GetProjectResult> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id, cancellationToken);
            var result = new GetProjectResult();

            if (project == null)
                throw new Exception("Project with given Id not found");

            if (project.OwnerId.HasValue)
            {
                var owner = await _userRepository.GetUserById(project.OwnerId.Value, cancellationToken);
                result.OwnerLogin = owner?.Login;
            }
            result.Description = project?.Description;
            result.Name = project?.Name;

            return result;
        }
    }
}
