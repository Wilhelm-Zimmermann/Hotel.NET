
using Hotel.Domain.Entities;

namespace Hotel.Domain.Repositories.Contracts
{
    public interface IUsersRepository
    {
        Task CreateUser(User user);
        Task<User> FindUserById(Guid user_id);
        Task<User> FindUserByName(string username);
    }
}
