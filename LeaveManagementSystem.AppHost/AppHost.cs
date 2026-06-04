var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithDbGate();
var postgresdb = postgres.AddDatabase("leave-management-system");

builder.AddProject<Projects.LeaveManagementSystem>("leavemanagementsystem").WithReference(postgresdb).WaitFor(postgresdb);

builder.Build().Run();
