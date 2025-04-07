using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure;

namespace ProjectManager.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddNewProject(Project project, CancellationToken cancellationToken)
        {
            var addedProject = await _context.Projects.AddAsync(project, cancellationToken);

            await _context.SaveChangesAsync();

            return addedProject.Entity;
        }

        public async Task<bool> DeleteProject(int id, CancellationToken cancellationToken)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);

            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                var result = await _context.SaveChangesAsync(cancellationToken);

                return result == 1;
            }
            return false;
        }

        public async Task<Project> GetProjectById(int id, CancellationToken cancellationToken)
        {
            return (await _context.Projects.FindAsync(id, cancellationToken))!;
        }

        public async Task<Project> UpdateProject(Project project, CancellationToken cancellationToken)
        {
            var updatedProject = _context.Projects.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return updatedProject.Entity;
        }
    }
}
