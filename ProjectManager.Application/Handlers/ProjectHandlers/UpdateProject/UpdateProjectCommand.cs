using ProjectManager.Application.Handlers.ProjectHandlers.CreateProject;

namespace ProjectManager.Application.Handlers.ProjectHandlers.UpdateProject
{
    internal class UpdateProjectCommand : CreateProjectCommand
    {
        public int Id { get; set; }
    }
}
