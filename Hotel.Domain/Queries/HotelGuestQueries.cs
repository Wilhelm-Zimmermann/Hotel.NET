using System.Linq.Expressions;
using Hotel.Domain.Entities;

namespace Hotel.Domain.Queries
{
    public static class HotelGuestQueries
    {
        public static Expression<Func<HotelGuest, bool>> GetHotelGuestById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}