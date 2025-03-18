using MediatR;

namespace ProjectManager.Application.Handlers.ProjectHandlers.GetProject
{
    internal class GetProjectQuery : IRequest<GetProjectResult>
    {
        public int Id { get; set; }
    }
}
