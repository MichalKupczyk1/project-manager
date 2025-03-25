using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Handlers.UserHandlers.CreateUser;
using ProjectManager.Application.Handlers.UserHandlers.DeleteUser;
using ProjectManager.Application.Handlers.UserHandlers.GetUser;
using ProjectManager.Application.Handlers.UserHandlers.UpdateUser;
using ProjectManager.Models.DTO.User;

namespace ProjectManager.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string GetUserStr = "GetUser";
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = GetUserStr)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var getQuery = new GetUserQuery() { Id = id };

            var result = await _mediator.Send(getQuery, cancellationToken);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDTO userDTO, CancellationToken cancellationToken)
        {
            var createCommand = new CreateUserCommand() { Email = userDTO.Email, Login = userDTO.Login, Password = userDTO.Password };

            var result = await _mediator.Send(createCommand, cancellationToken);

            return result != null ? CreatedAtRoute(GetUserStr, routeValues: new { id = result.Data }, value: result.IsSuccess) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id, CancellationToken cancellationToken)
        {
            var deleteCommand = new DeleteUserCommand() { Id = id };

            var result = await _mediator.Send(deleteCommand, cancellationToken);

            return result != null ? Ok(result.IsSuccess) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO, CancellationToken cancellationToken)
        {
            var updateCommand = new UpdateUserCommand()
            {
                Email = userUpdateDTO.Email,
                Id = userUpdateDTO.Id,
                Login = userUpdateDTO.Login,
                Password = userUpdateDTO.Password
            };

            var result = await _mediator.Send(updateCommand, cancellationToken);

            return result != null ? Ok(result.IsSuccess) : BadRequest();
        }
    }
}
