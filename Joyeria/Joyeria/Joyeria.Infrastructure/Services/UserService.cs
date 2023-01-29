﻿using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Services;
using Joyeria.Domain.Entities;

namespace Joyeria.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> CreateAsync(User createToUser)
        {
            await _unitOfWork.Users.CreateAsync(createToUser);
            await _unitOfWork.SaveChangesAsync();
            return createToUser;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.Users.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateAsync(User userToUpdate)
        {
            await _unitOfWork.Users.UpdateAsync(userToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
