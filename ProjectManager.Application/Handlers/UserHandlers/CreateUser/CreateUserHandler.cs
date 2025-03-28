﻿using MediatR;
using ProjectManager.Application.Shared;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Handlers.UserHandlers.CreateUser
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userToAdd = new User()
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password
            };

            var addedUser = await _userRepository.AddNewUser(userToAdd, cancellationToken);

            return new CommandResult()
            {
                IsSuccess = addedUser != null,
                Data = addedUser?.Id
            };
        }
    }
}
