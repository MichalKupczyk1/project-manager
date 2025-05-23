﻿using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Exceptions;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.ProjectHandlers.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, CommandResult>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;


        public CreateProjectHandler(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<CommandResult> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                OwnerId = request.OwnerId,
                Owner = request.OwnerId.HasValue ? await _userRepository.GetUserById(request.OwnerId.Value, cancellationToken) : null,
            };

            var addedProject = await _projectRepository.AddNewProject(project, cancellationToken);

            if (addedProject == null)
                throw new Exception("Failed to add new project with given data");

            return new CommandResult() { IsSuccess = project != null, Data = project?.Id };
        }
    }
}
