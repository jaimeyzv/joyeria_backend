using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.UserUC.Commands
{
    public class UserCommands : IUserCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateAsync(UserModel createToUser)
        {
            var domain = _mapper.Map<User>(createToUser);
            await _unitOfWork.Users.CreateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return createToUser;
        }
        public async Task<UserModel> UpdateAsync(UserModel userToUpdate)
        {
            var domain = _mapper.Map<User>(userToUpdate);
            await _unitOfWork.Users.UpdateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
