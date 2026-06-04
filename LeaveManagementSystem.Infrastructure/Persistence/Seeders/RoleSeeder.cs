using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Infrastructure.Persistence.Seeders
{
    public class RoleSeeder(RoleManager<IdentityRole> roleManager)
    {
        private static readonly string[] Roles = ["Admin", "Manager", "Employee"];

        public async Task SeedAsync()
        {
            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
