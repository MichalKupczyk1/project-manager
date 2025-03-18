using MediatR;

namespace ProjectManager.Application.Handlers.GetUser
{
    public class GetUserQuery : IRequest<GetUserResult>
    {
        public int Id { get; set; }
    }
}
