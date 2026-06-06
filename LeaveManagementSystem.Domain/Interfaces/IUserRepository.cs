using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetUserById(string id);
    }
}
