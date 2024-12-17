using NorthPole.Core.SantasSleigh;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<ISleighEngine, SleighEngine>();

var endpointConfiguration = new EndpointConfiguration("santas-sleigh");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
transport.Routing().RouteToEndpoint(
  typeof(SleighContainsNewPresentEvent),
  "santas-sleigh");

builder.UseNServiceBus(endpointConfiguration);

var host = builder.Build();
host.Run();
