using Hotel.Domain.Commands;
using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers.Contracts;
using Hotel.Domain.Repositories.Contracts;
using System.Xml.Linq;

namespace Hotel.Domain.Handlers
{
    public class EscortHandler : IHandler<CreateEscortCommand>
    {
        private readonly IEscortsRepository _repository;

        public EscortHandler(IEscortsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateEscortCommand command)
        {
            var escort = new Escort(command.Name, command.Relationship, command.BirthDate, command.HotelGuestId);

            await _repository.CreateEscort(escort);

            return new GenericCommandResult("Escort was created", true, escort);
        }
    }
}
