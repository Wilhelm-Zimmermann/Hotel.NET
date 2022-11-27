using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories.Contracts
{
    public interface IEscortsRepository
    {
        Task CreateEscort(Escort escort);
        Task UpdateEscort(Escort escort);
        Task<IEnumerable<Escort>> GetAllEscorts();
        Task DeleteEscort(Escort escort);
        Task<Escort> GetEscortById(Guid id);
        Task<IEnumerable<Escort>> GetEsortsByHotelGuestId(Guid hotelGuestId);
    }
}
