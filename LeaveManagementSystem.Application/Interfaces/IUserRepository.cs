using LeaveManagementSystem.Application.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(CreateUserRequest user);
    }
}
