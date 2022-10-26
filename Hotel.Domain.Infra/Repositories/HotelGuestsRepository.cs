using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Queries;

namespace Hotel.Domain.Infra.Repositories
{
    public class HotelGuestsRepository : IHotelGuestsRepository
    {
        private readonly DatabaseContext _context;

        public HotelGuestsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateHotelGuest(HotelGuest hotelGuest)
        {
            _context.HotelGuests.Add(hotelGuest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotelGuest(HotelGuest hotelGuest)
        {
            _context.Entry(hotelGuest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelGuest>> GetAllHotelGuests()
        {
            return await _context.HotelGuests.ToListAsync();
        }

        public async Task<HotelGuest> GetHotelGuestById(Guid id)
        {
            return await _context.HotelGuests.FirstOrDefaultAsync(HotelGuestQueries.GetHotelGuestById(id));    
        }

        public async Task DeleteHotelGuest(HotelGuest hotelGuest)
        {
            _context.HotelGuests.Remove(hotelGuest);
            await _context.SaveChangesAsync();
        }
    }
}