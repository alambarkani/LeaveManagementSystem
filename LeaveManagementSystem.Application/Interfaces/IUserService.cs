using LeaveManagementSystem.Application.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest request);
        Task<List<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserById(string id);
        Task<List<string?>> GetAvailableRolesAsync();
        Task<List<UserResponse>> GetAllManagersAsync();
    }
}
