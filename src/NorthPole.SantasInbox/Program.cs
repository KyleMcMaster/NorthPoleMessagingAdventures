using NorthPole.Core.Gifts;
using NorthPole.Core.NaughtyOrNice;

var builder = Host.CreateApplicationBuilder(args);

var endpointConfiguration = new EndpointConfiguration("santas-inbox");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
transport.Routing().RouteToEndpoint(
  typeof(CreatePresentCommand),
  "santas-workshop");

builder.UseNServiceBus(endpointConfiguration);

builder.Services.AddScoped<NaughtyOrNiceList>();

var host = builder.Build();
host.Run();
