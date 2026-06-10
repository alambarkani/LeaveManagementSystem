using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.UserDTO
{
    public class EditUserRequest
    {
        public string Role { get; set; } = "Employee";
        public string? ManagerId { get; set; }
    }
}
