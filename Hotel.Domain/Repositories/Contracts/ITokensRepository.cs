using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories.Contracts
{
    public interface ITokensRepository
    {
        Task CreateToken(Token token);
        Task UpdateToken(Token token);
        Task<IEnumerable<Token>> GetAllTokens();
        Task<Token> GetTokenById(Guid id);
    }
}