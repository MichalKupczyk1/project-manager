using AutoMapper;
using MediatR;
using ProjectManager.Domain.Exceptions;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.ProjectHandlers.GetProject
{
    internal class GetProjectHandler : IRequestHandler<GetProjectQuery, GetProjectResult>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<GetProjectResult> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id, cancellationToken);

            if (project == null)
                throw new BadRequestException("Project with given Id not found");

            return _mapper.Map<GetProjectResult>(project);
        }
    }
}
