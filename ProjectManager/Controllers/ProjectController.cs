using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Handlers.ProjectHandlers.CreateProject;
using ProjectManager.Application.Handlers.ProjectHandlers.DeleteProject;
using ProjectManager.Application.Handlers.ProjectHandlers.GetProject;
using ProjectManager.Application.Handlers.ProjectHandlers.UpdateProject;
using ProjectManager.Database.Entities;

namespace ProjectManager.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getProjectQuery = new GetProjectQuery() { Id = id };

                var result = await _mediator.Send(getProjectQuery);
                return result != null ? Ok(result) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteProjectCommand = new DeleteProjectCommand() { Id = id };

            var result = await _mediator.Send(deleteProjectCommand);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            var createProject = new CreateProjectCommand() { Name = project.Name, Description = project.Description, OwnerId = project.OwnerId };

            var result = await _mediator.Send(createProject);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            var updateProjectCommand = new UpdateProjectCommand() { Id = project.Id, Description = project.Description, Name = project.Name, OwnerId = project.OwnerId };

            var updatedProject = await _mediator.Send(updateProjectCommand);

            return updatedProject != null ? Ok(updatedProject) : BadRequest();
        }
    }
}
