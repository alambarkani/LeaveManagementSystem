using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.UserDTO
{
    public class UserResponse
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? ManagerId { get; set; }
    }
}
