using Hotel.Domain.Commands;
using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers.Contracts;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Validators;
using System.Xml.Linq;

namespace Hotel.Domain.Handlers
{
    public class EscortHandler : IHandler<CreateEscortCommand>, IHandler<UpdateEscortCommand>
    {
        private readonly IEscortsRepository _repository;

        public EscortHandler(IEscortsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateEscortCommand command)
        {
            var escort = new Escort(command.Name, command.Relationship, command.BirthDate, command.HotelGuestId);
            var escortValidator = new EscortValidator(escort);
            escortValidator.Validate();

            if (!escortValidator.IsValid)
                return new GenericCommandResult("Some Field might be invalid", false, null);

            await _repository.CreateEscort(escort);

            return new GenericCommandResult("Escort was created", true, escort);
        }

        public async Task<ICommandResult> Handle(UpdateEscortCommand command)
        {
            var escort = await _repository.GetEscortById(command.Id);

            escort.UpdateName(command.Name);
            escort.UpdateBirthDate(command.BirthDate);
            escort.UpdateRelationship(command.Relationship);

            var escortValidator = new EscortValidator(escort);
            escortValidator.Validate();

            if (!escortValidator.IsValid)
                return new GenericCommandResult("Some Field might be invalid", false, null);

            await _repository.UpdateEscort(escort);

            return new GenericCommandResult("Updated successfully", true, escort);
        }
    }
}
