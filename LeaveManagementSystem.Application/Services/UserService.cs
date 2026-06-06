using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Services
{
    public class UserService(IUserRepository userRepo) : IUserService
    {
        public async Task CreateUserAsync(CreateUserRequest req)
        {
            var user = new User
            {
                FullName = req.FullName,
                UserName = req.UserName,
                Email = req.Email,
                Password = req.Password,
                Role = req.Role,
                ManagerId = req.ManagerId
            };
            await userRepo.CreateAsync(user);
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await userRepo.GetAllAsync();
            return [..users.Select(u => new UserResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName,
                Role = u.Role,
                ManagerId = u.ManagerId
            })];
        }

        public async Task<UserResponse> GetUserById(string id)
        {
            var user = await userRepo.GetUserById(id);
            return new UserResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                Role = user.Role,
                ManagerId = user.ManagerId
            };
        }
    }
}
