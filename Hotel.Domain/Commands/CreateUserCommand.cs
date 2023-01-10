

using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public CreateUserCommand()
        {

        }

        public CreateUserCommand(string name, string password, string role)
        {
            Name = name;
            Password = password;
        }
    }
}
