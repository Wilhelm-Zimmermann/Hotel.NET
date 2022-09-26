using Hotel.Domain.Handlers.Contracts;
using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories.Contracts;

namespace Hotel.Domain.Handlers
{
    public class TokenHandler : IHandler<CreateTokenCommand>
    {
        private readonly ITokensRepository _repository;

        public TokenHandler(ITokensRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateTokenCommand command)
        {
            var token = new Token
            (
                command.Name,
                command.Om,
                command.BirthDate,
                command.PhoneNumber,
                command.Email
            );

            await _repository.CreateToken(token);

            var result = new GenericCommandResult("Created Successfully", true, token);

            return result;
        }
    }
}