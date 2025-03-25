using MediatR;

namespace ProjectManager.Application.Handlers.UserHandlers.GetUser
{
    public class GetUserQuery : IRequest<GetUserResult>
    {
        public int Id { get; set; }
    }
}
