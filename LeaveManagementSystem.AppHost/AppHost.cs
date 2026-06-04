var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.LeaveManagementSystem>("leavemanagementsystem");

builder.Build().Run();
