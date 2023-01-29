using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateAsync(User createToUser);
        Task<User> UpdateAsync(User userToUpdate);
    }
}
