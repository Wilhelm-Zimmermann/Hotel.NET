using Hotel.Domain.Commands.Contracts;
using Hotel.Domain.Entities;

namespace Hotel.Domain.Commands
{
    public class CreateEscortCommand : ICommand
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid HotelGuestId { get; set; }

        public CreateEscortCommand()
        {

        }

        public CreateEscortCommand(string name, string relationship, DateTime birthDate, Guid hotelGuestId)
        {
            Name = name;
            Relationship = relationship;
            BirthDate = birthDate;
            HotelGuestId = hotelGuestId;
        }
    }
}
