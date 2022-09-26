using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Queries;

namespace Hotel.Domain.Infra.Repositories
{
    public class TokensRepository : ITokensRepository
    {
        private readonly DatabaseContext _context;

        public TokensRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateToken(Token token)
        {
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Token>> GetAllTokens()
        {
            return await _context.Tokens.ToListAsync();
        }

        public async Task<Token> GetTokenById(Guid id)
        {
            return await _context.Tokens.FirstOrDefaultAsync(TokenQueries.GetTokenById(id));    
        }
    }
}