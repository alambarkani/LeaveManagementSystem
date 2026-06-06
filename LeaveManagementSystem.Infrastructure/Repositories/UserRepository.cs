using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Domain.Interfaces;
using LeaveManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Infrastructure.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> userManager) : IUserRepository
    {
        public async Task CreateAsync(User user)
        {
            var newUser = new ApplicationUser
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName
            };

            var result = await userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create user: {errors}");
            }

            await userManager.AddToRoleAsync(newUser, user.Role);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return [.. users.Select(u => new User
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email ?? "",
                UserName = u.UserName ?? "",
                Role = userManager.GetRolesAsync(u).Result.FirstOrDefault() ?? "Employee",
                Password = string.Empty,
                ManagerId = u.ManagerId,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                DeletedAt = u.DeletedAt
            })];
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user is null ? throw new KeyNotFoundException($"User with ID {id} not found.") : new User
            {
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                Role = userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "Employee",
                Password = string.Empty,
                ManagerId = user.ManagerId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                DeletedAt = user.DeletedAt
            };
        }
    }
}
