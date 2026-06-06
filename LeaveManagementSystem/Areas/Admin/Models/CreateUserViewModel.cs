using LeaveManagementSystem.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LeaveManagementSystem.Areas.Admin.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }
        [Required]
        [MinLength(4)]
        [StringLength(100)]
        public required string UserName { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [Required]
        [StringLength(255)]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
        [AllowedValues("Admin", "Manager", "Employee")]
        public string Role { get; set; } = "Employee";
        public string? ManagerId { get; set; }
    }
}
