using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public required string Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [AllowedValues("Admin", "Manager", "Employee")]
        public string Role { get; set; } = "Employee";
        public string? ManagerId { get; set; }
    }
}
