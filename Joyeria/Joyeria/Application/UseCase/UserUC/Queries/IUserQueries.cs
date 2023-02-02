using Joyeria.Application.UseCase.UserUC.Commands;

namespace Joyeria.Application.UseCase.UserUC.Queries
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<UserModel> GetUserByIdAsync(int id);

        
    }
}
