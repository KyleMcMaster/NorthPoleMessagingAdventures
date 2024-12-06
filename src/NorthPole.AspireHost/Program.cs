var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NorthPole_Web>("web");

builder.Build().Run();
