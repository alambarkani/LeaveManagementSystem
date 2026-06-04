using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Infrastructure.Persistence.Seeders
{
    public class UserSeeder(UserManager<ApplicationUser> userManager)
    {
        public async Task SeedAsync()
        {
            if (await userManager.FindByEmailAsync("admin@company.com") is not null)
                return; // sudah ada, skip

            var admin = new ApplicationUser
            {
                Email = "admin@company.com",
                FullName = "System Admin",
                UserName = "admin",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, "Admin@123456");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
