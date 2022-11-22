using Hotel.Domain.Entities;
using System.Linq.Expressions;

namespace Hotel.Domain.Queries
{
    public static class EscortQueries
    {
        public static Expression<Func<Escort, bool>> GetEscortById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
