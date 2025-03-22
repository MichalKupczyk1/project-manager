using MediatR;

namespace ProjectManager.Application.Handlers.ProjectHandlers.GetProject
{
    public class GetProjectQuery : IRequest<GetProjectResult>
    {
        public int Id { get; set; }
    }
}
