using Hotel.Domain.Entities;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Domain.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _context;

        public UsersRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindUserById(Guid user_id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == user_id);
        }

        public async Task<User> FindUserByName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == username);
        }
    }
}
