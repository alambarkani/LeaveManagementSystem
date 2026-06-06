using LeaveManagementSystem.Application.DTOs.UserDTO;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
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
