using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Services
{
    public class UserService(IUserRepository createUserRepository)
    {
        public async Task CreateUserAsync(CreateUserRequest user)
        {
            await createUserRepository.CreateAsync(user);
        }
    }
}
