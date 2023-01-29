using Joyeria.Application.Interfaces.Repositories;
using Joyeria.Domain.Entities;
using Joyeria.Persitance.Shared;
using Microsoft.EntityFrameworkCore;

namespace Joyeria.Persitance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JoyeriaDbContext _dbContext;


        public UserRepository(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<User> CreateAsync(User createToUser)
        {
            await _dbContext.Users.AddAsync(createToUser);
            return createToUser;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await this._dbContext.Users.ToListAsync();

        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        public async Task<User> UpdateAsync(User userToUpdate)
        {
            _dbContext.Users.Update(userToUpdate);
            return await Task.FromResult(userToUpdate);
        }
    }
}
