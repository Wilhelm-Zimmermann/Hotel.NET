using System.Linq.Expressions;
using Hotel.Domain.Entities;

namespace Hotel.Domain.Queries
{
    public static class TokenQueries
    {
        public static Expression<Func<Token, bool>> GetTokenById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}