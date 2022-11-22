using Hotel.Domain.Entities;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Queries;
using Hotel.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Domain.Infra.Repositories
{
    public class EscortsRepository : IEscortsRepository
    {
        private readonly DatabaseContext _context;

        public EscortsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateEscort(Escort escort)
        {
            _context.Escorts.Add(escort);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEscort(Escort escort)
        {
            _context.Escorts.Remove(escort);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Escort>> GetAllEscorts()
        {
            return await _context.Escorts.ToListAsync();
        }

        public async Task<Escort> GetEscortById(Guid id)
        {
            return await _context.Escorts.FirstOrDefaultAsync(EscortQueries.GetEscortById(id));
        }

        public async Task<IEnumerable<Escort>> GetEsortsByHotelGuestId(Guid hotelGuestId)
        {
            return await _context.Escorts.Where(e => e.HotelGuestId == hotelGuestId).ToListAsync();
        }

        public async Task UpdateEscort(Escort escort)
        {
            _context.Entry(escort).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
