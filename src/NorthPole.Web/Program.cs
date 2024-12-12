using NorthPole.Core.Letters;
using NorthPole.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

builder.AddLoggerConfigs();

var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
builder.Services.AddServiceConfigs(appLogger, builder);

builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                });

builder.AddServiceDefaults();

builder.Host.UseNServiceBus(_ =>
{
  var endpointConfiguration = new EndpointConfiguration("north-pole-api");
  
  var transport = endpointConfiguration.UseTransport<LearningTransport>();

  transport.Routing().RouteToEndpoint(
    typeof(LetterToSanta),
    "santas-inbox");

  endpointConfiguration.SendOnly();
  endpointConfiguration.EnableInstallers();

  return endpointConfiguration;
});

var app = builder.Build();

await app.UseAppMiddlewareAndSeedDatabase();

app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program { }
