using NorthPole.Core.Elves;
using NorthPole.Core.Presents;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IElfAssigner, ElfAssigner>();

var endpointConfiguration = new EndpointConfiguration("santas-workshop");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
transport.Routing().RouteToEndpoint(
  typeof(AddPresentToSleighCommand),
  "santas-sleigh");

builder.UseNServiceBus(endpointConfiguration);

var host = builder.Build();
host.Run();
