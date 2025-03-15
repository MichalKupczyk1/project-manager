using ProjectManager.Database.Entities;

namespace ProjectManager.Database.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> AddNewProject(Project project);
        Task<bool> DeleteProject(int id);
        Task<Project> GetProjectById(int id);
        Task<Project> UpdateProject(Project project);
    }
}
