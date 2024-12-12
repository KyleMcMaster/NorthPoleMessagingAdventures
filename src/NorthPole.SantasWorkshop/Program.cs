using NorthPole.Core.Gifts;
using NorthPole.SantasWorkshop;

var builder = Host.CreateApplicationBuilder(args);
var endpointConfiguration = new EndpointConfiguration("santas-workshop");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
transport.Routing().RouteToEndpoint(
  typeof(AddGiftToSleighCommand),
  "santas-sleigh");

builder.UseNServiceBus(endpointConfiguration);

var host = builder.Build();
host.Run();
