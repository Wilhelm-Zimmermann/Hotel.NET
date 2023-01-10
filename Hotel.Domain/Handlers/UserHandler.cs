using Hotel.Domain.Commands;
using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers.Contracts;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Utils;

namespace Hotel.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>, IHandler<LoginUserCommand>
    {
        private readonly IUsersRepository _repository;

        public UserHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            var hashedPassword = PasswordHash.Hash(command.Password);
            var user = new User(command.Name, hashedPassword, "manager");

            await _repository.CreateUser(user);

            return new GenericCommandResult("User Created", true, user);
        }

        public async Task<ICommandResult> Handle(LoginUserCommand command)
        {
            var user = await _repository.FindUserByName(command.Name);

            if (user == null)
            {
                return new GenericCommandResult("User not found", false, null);
            }

            return new GenericCommandResult("User found", true, user);
        }
    }
}
