using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.UserUC.Commands;

namespace Joyeria.Application.UseCase.UserUC.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var domain = await _unitOfWork.Users.GetUserByIdAsync(id);
            var model = _mapper.Map<UserModel>(domain);
            return model;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var domain = await _unitOfWork.Users.GetUsersAsync();
            var model = _mapper.Map<IEnumerable<UserModel>>(domain);
            return model;
        }
    }
}
