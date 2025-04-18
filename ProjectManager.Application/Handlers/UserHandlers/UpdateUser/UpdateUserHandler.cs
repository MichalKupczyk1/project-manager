﻿using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.UserHandlers.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserById(request.Id, cancellationToken);
            var success = false;

            if (userToUpdate != null)
            {
                UpdateUserData(userToUpdate, request);
                var result = await _userRepository.UpdateUser(userToUpdate, cancellationToken);
                success = result != null;
            }

            if (!success)
                throw new Exception("Failed to update user");

            return new CommandResult() { IsSuccess = success };
        }

        private void UpdateUserData(User user, UpdateUserCommand data)
        {
            user.Email = data.Email;
            user.Login = data.Login;
            user.Password = data.Password;
        }
    }
}
