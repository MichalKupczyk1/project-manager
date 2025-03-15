using Microsoft.AspNetCore.Mvc;
using ProjectManager.Database.Entities;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            return user != null ? Ok(user) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var addedUser = await _userRepository.AddNewUser(user);

            return addedUser != null ? Ok(addedUser) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);

            return deleted ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var updatedUser = await _userRepository.UpdateUser(user);

            return updatedUser != null ? Ok(updatedUser) : BadRequest();
        }
    }
}
