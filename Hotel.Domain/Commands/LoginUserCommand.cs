
using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public LoginUserCommand()
        {

        }

        public LoginUserCommand(string name, string password, string role)
        {
            Name = name;
            Password = password;
        }
    }
}
