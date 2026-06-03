using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveManagementSystem.Domain.Entities
{
    public class User
    {
        public uint Id { get; set; }
        [StringLength(100)]
        public required string FullName { get; set; }
        [StringLength(100)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [StringLength(255)]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public Role Role { get; set; } = Role.Employee;
        public uint ManagerId { get; set; }
        public User? Manager { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }

    public enum Role
    {
        Manager,
        Employee,
        HR
    }
}
