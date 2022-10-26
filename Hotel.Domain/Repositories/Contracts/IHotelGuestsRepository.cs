using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories.Contracts
{
    public interface IHotelGuestsRepository
    {
        Task CreateHotelGuest(HotelGuest hotelGuest);
        Task UpdateHotelGuest(HotelGuest hotelGuest);
        Task<IEnumerable<HotelGuest>> GetAllHotelGuests();
        Task<HotelGuest> GetHotelGuestById(Guid id);
        Task DeleteHotelGuest(HotelGuest hotelGuest);
    }
}