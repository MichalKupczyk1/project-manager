using Microsoft.AspNetCore.Mvc;
using ProjectManager.Database.Entities;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectRepository.GetProjectById(id);

            return project != null ? Ok(project) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _projectRepository.DeleteProject(id) ? Ok() : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            var addedProject = await _projectRepository.AddNewProject(project);

            return addedProject != null ? Ok(addedProject) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            var updatedProject = await _projectRepository.UpdateProject(project);

            return updatedProject != null ? Ok(updatedProject) : BadRequest();
        }
    }
}
