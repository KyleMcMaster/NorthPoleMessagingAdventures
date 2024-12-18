var builder = Host.CreateApplicationBuilder(args);

var endpointConfiguration = new EndpointConfiguration("santas-sleigh");
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
endpointConfiguration.UseTransport<LearningTransport>();

builder.UseNServiceBus(endpointConfiguration);

var host = builder.Build();
host.Run();
