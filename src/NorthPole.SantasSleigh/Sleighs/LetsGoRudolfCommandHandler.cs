using Ardalis.SharedKernel;
using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;
public class LetsGoRudolfCommandHandler : IHandleMessages<LetsGoRudolfCommand>
{
  private readonly ILogger<LetsGoRudolfCommandHandler> _logger;
  private readonly IRepository<Sleigh> _repository;

  public LetsGoRudolfCommandHandler(ILogger<LetsGoRudolfCommandHandler> logger, IRepository<Sleigh> repository)
  {
    _logger = logger;
    _repository = repository;
  }

  public Task Handle(LetsGoRudolfCommand message, IMessageHandlerContext context)
  {
    _logger.LogInformation("Received command to unleash Rudolf's true potential!");
    // TODO: var sleigh = await _repository.GetByIdAsync(message.SleighId);
    Sleigh _sleigh = new([]);
    _sleigh.Takeoff();
    _logger.LogInformation("Rudolf has saved the day!");
    return Task.CompletedTask;
  }
}
