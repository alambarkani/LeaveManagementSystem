using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        [AllowedValues("Admin", "Manager", "Employee")]
        public string Role { get; set; } = "Employee";
        public string? ManagerId { get; set; }
    }
}
