

namespace Hotel.Domain.Entities
{
    public class Escort : Base
    {
        public string Name { get; private set; }
        public string Relationship { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Guid HotelGuestId { get; private set; }
        public HotelGuest HotelGuest { get; private set; }

        public Escort(string name, string relationship, DateTime birthDate, Guid hotelGuestId)
        {
            Name = name;
            Relationship = relationship;
            BirthDate = birthDate;
            HotelGuestId = hotelGuestId;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateRelationship(string relationship)
        {
            Relationship = relationship;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
    }
}
