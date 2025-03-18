﻿using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Database.Entities;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Application.Handlers.ProjectHandlers.UpdateProject
{
    internal class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, CommandResult>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<CommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectToUpdate = await _projectRepository.GetProjectById(request.Id);
            if (projectToUpdate == null)
                return new CommandResult() { IsSuccess = false };

            var updatedProject = await UpdateProjectData(request, projectToUpdate);

            return new CommandResult() { IsSuccess = updatedProject != null, Data = updatedProject?.Id };
        }

        private async Task<Project> UpdateProjectData(UpdateProjectCommand request, Project projectToUpdate)
        {
            projectToUpdate.Name = request.Name;
            projectToUpdate.Description = request.Description;
            projectToUpdate.OwnerId = request.OwnerId;

            return await _projectRepository.UpdateProject(projectToUpdate);
        }
    }
}
