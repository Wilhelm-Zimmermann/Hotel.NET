

namespace Hotel.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public User()
        {

        }

        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetRole(string role)
        {
            Role = role;
        }
    }
}
