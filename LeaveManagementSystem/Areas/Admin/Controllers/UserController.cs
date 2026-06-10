using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(IUserService userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsersAsync();
            List<UserListViewModel> userList = [.. users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                UserName = u.UserName,
                Role = u.Role,
                ManagerId = u.ManagerId
            })];
            return View(userList);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateRolesAndManagersAsync();
            return View();
        }

        private async Task PopulateRolesAndManagersAsync()
        {
            var roles = await userService.GetAvailableRolesAsync();
            ViewBag.Roles = new SelectList(roles);
            var managers = await userService.GetAllManagersAsync();
            ViewBag.Managers = new SelectList(managers, "Id", "FullName");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateRolesAndManagersAsync();
                return View(model);
            }
            


            // Call the service to create the user
            var user = new CreateUserRequest
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
                ManagerId = model.ManagerId
            };
            await userService.CreateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
