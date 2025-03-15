using ProjectManager.Database.Entities;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Database.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Project> AddNewProject(Project project)
        {
            var addedProject = await _context.Projects.AddAsync(project);

            await _context.SaveChangesAsync();

            return addedProject.Entity;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);

            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                var result = await _context.SaveChangesAsync();

                return result == 1;
            }
            return false;
        }

        public async Task<Project> GetProjectById(int id)
        {
            return (await _context.Projects.FindAsync(id))!;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var updatedProject = _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return updatedProject.Entity;
        }
    }
}
