var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NorthPole_Web>("North-Pole-Api");

builder.AddProject<Projects.NorthPole_SantasInbox>("Santas-Inbox");

builder.AddProject<Projects.NorthPole_SantasWorkshop>("Santas-Workshop");

builder.AddProject<Projects.NorthPole_SantasSleigh>("Santas-Sleigh");

builder.AddProject<Projects.WorldWide_Homes>("Chimneys-Worldwide");

builder.Build().Run();
