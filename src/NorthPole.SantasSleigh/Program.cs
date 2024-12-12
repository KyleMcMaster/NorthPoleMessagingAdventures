

var builder = Host.CreateApplicationBuilder(args);
var endpointConfiguration = new EndpointConfiguration("santas-sleigh");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
// transport.Routing().RouteToEndpoint(
//   typeof(CreateGiftCommand),
//   "santas-workshop");

builder.UseNServiceBus(endpointConfiguration);

var host = builder.Build();
host.Run();
