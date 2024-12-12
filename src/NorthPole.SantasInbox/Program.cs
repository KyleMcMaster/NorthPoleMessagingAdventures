using NorthPole.Core.NaughtyOrNice;
using NorthPole.SantasInbox;
using NorthPole.SantasInbox.Inbox;

var builder = Host.CreateApplicationBuilder(args);

var endpointConfiguration = new EndpointConfiguration("santas-inbox");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = endpointConfiguration.UseTransport<LearningTransport>();
transport.Routing().RouteToEndpoint(
  typeof(CreateGiftCommand),
  "santas-workshop");

builder.UseNServiceBus(endpointConfiguration);

builder.Services.AddScoped<NaughtyOrNiceList>();

var host = builder.Build();
host.Run();
