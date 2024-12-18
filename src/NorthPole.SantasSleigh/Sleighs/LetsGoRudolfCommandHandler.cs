using Ardalis.SharedKernel;
using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class LetsGoRudolfCommandHandler(ILogger<LetsGoRudolfCommandHandler> logger, IRepository<Sleigh> repository) : IHandleMessages<LetsGoRudolfCommand>
{
  private readonly ILogger<LetsGoRudolfCommandHandler> _logger = logger;
  private readonly IRepository<Sleigh> _repository = repository;

  public async Task Handle(LetsGoRudolfCommand message, IMessageHandlerContext context)
  {
    _logger.LogInformation("Received command to unleash Rudolf's true potential!");
    var sleigh = await _repository.SingleOrDefaultAsync(new SantasSleighSpecification(), context.CancellationToken);
    sleigh!.Takeoff();
    await context.Publish(new SleighHasTakenOffEvent());
    _logger.LogInformation("Rudolf has saved the day!");
  }
}
