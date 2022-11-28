using Hotel.Domain.Handlers.Contracts;
using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Validators;

namespace Hotel.Domain.Handlers
{
    public class HotelGuestHandler : IHandler<CreateHotelGuestCommand>, IHandler<UpdateHotelGuestCommand>
    {
        private readonly IHotelGuestsRepository _repository;

        public HotelGuestHandler(IHotelGuestsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateHotelGuestCommand command)
        {
            var hotelGuest = new HotelGuest
            (
                command.Name,
                command.Om,
                command.BirthDate,
                command.PhoneNumber,
                command.Email
            );

            var hotelGuestValidator = new HotelGuestValidator(hotelGuest);
            hotelGuestValidator.Validate();

            if (!hotelGuestValidator.IsValid)
                new GenericCommandResult("Some fields might be invalid", false, null);

            await _repository.CreateHotelGuest(hotelGuest);

            var result = new GenericCommandResult("Created Successfully", true, hotelGuest);

            return result;
        }

        public async Task<ICommandResult> Handle(UpdateHotelGuestCommand command)
        {
            var hotelGuest = await _repository.GetHotelGuestById(command.Id);

            hotelGuest.UpdatePhoneNumber(command.PhoneNumber);
            hotelGuest.UpdateName(command.Name);
            hotelGuest.UpdateOM(command.Om);
            hotelGuest.UpdateBirthDate(command.BirthDate);
            hotelGuest.UpdateEmail(command.Email);

            var hotelGuestValidator = new HotelGuestValidator(hotelGuest);
            hotelGuestValidator.Validate();

            if (!hotelGuestValidator.IsValid)
                new GenericCommandResult("Some fields might be invalid", false, null);

            await _repository.UpdateHotelGuest(hotelGuest);

            var result = new GenericCommandResult("Created Successfully", true, hotelGuest);

            return result;
        }
    }
}