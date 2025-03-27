using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> AddNewProject(Project project, CancellationToken cancellationToken);
        Task<bool> DeleteProject(int id, CancellationToken cancellationToken);
        Task<Project> GetProjectById(int id, CancellationToken cancellationToken);
        Task<Project> UpdateProject(Project project, CancellationToken cancellationToken);
    }
}
