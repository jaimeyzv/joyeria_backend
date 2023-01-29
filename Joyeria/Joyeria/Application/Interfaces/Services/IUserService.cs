﻿using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);
       
        Task<User> CreateAsync(User createToUser);

        Task<User> UpdateAsync(User userToUpdate);
    }
}
