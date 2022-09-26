namespace Hotel.Domain.Entities
{
    public class Token : Base
    {
        public string Name { get; private set; }
        public string Om { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Token()
        {
            
        }

        public Token(string name, string om, DateTime birthDate, string phoneNumber, string email)
        {
            Name = name;
            Om = om;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateOM(string om)
        {
            Om = om;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
    }
}