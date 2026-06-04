using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Infrastructure.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> userManager) : IUserRepository
    {
        public async Task CreateAsync(CreateUserRequest user)
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
    }
}
