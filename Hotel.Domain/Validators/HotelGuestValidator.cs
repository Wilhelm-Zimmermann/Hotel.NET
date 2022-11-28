

using Hotel.Domain.Entities;

namespace Hotel.Domain.Validators
{
    public class HotelGuestValidator : GenericValidator
    {
        public HotelGuest HotelGuestItem { get; private set; }

        public HotelGuestValidator(HotelGuest hotelGuestItem)
        {
            HotelGuestItem = hotelGuestItem;
            IsValid = true;
        }

        public void Validate()
        {
            if (HotelGuestItem.Name.Length <= 0 || HotelGuestItem.Om.Length <= 0)
                IsValid = false;
            
            if(HotelGuestItem.BirthDate >= DateTime.Now)
                IsValid = false;

            if (HotelGuestItem.PhoneNumber.Length <= 0)
                IsValid = false;
        }
    }
}
