using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class CreateTokenCommand : ICommand
    {
        public string Name { get; set; }
        public string Om { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CreateTokenCommand()
        {
            
        }

        public CreateTokenCommand(string name, string om, DateTime birthDate, string phoneNumber, string email)
        {
            Name = name;
            Om = om;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}