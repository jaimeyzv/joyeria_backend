using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.UserUC.Commands
{
    public interface IUserCommands
    {
        Task<UserModel> CreateAsync(UserModel createToUser);
        Task<UserModel> UpdateAsync(UserModel userToUpdate);
    }
}
