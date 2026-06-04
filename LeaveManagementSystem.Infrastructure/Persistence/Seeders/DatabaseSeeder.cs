using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Infrastructure.Persistence.Seeders
{
    public class DatabaseSeeder(RoleSeeder roleSeeder, UserSeeder userSeeder)
    {
        public async Task SeedAsync()
        {
            await roleSeeder.SeedAsync();
            await userSeeder.SeedAsync();
        }
    }
}
