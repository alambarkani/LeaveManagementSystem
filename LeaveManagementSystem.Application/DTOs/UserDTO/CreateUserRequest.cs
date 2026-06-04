using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.UserDTO
{
    public class CreateUserRequest
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = "Employee";
        public uint? ManagerId { get; set; }
    }
}
