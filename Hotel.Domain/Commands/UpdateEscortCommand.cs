using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class UpdateEscortCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid HotelGuestId { get; set; }

        public UpdateEscortCommand()
        {

        }

        public UpdateEscortCommand(string name, string relationship, DateTime birthDate,Guid id)
        {
            Name = name;
            Relationship = relationship;
            BirthDate = birthDate;
            Id = id;
        }
    }
}
