using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Handlers.CreateUser;
using ProjectManager.Application.Handlers.GetUser;
using ProjectManager.Application.Handlers.UserHandlers.UpdateUser;
using ProjectManager.Database.Repositories.Interfaces;
using ProjectManager.Models.DTO.User;

namespace ProjectManager.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string GetUserStr = "GetUser";
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = GetUserStr)]
        public async Task<IActionResult> GetById(int id)
        {
            var getQuery = new GetUserQuery() { Id = id };

            var result = await _mediator.Send(getQuery);

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDTO userDTO)
        {
            var createCommand = new CreateUserCommand() { Email = userDTO.Email, Login = userDTO.Login, Password = userDTO.Password };

            var result = await _mediator.Send(createCommand);

            return result != null ? CreatedAtRoute(GetUserStr, routeValues: new { id = result.Data }, value: result.IsSuccess) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);

            return deleted ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var updateCommand = new UpdateUserCommand()
            {
                Email = userUpdateDTO.Email,
                Id = userUpdateDTO.Id,
                Login = userUpdateDTO.Login,
                Password = userUpdateDTO.Password
            };

            var result = await _mediator.Send(updateCommand);

            return result != null ? Ok(result.IsSuccess) : BadRequest();
        }
    }
}
