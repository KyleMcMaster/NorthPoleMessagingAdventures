using Ardalis.SharedKernel;
using NorthPole.Core.Chimneys;
using NorthPole.Core.SantasSleigh;

namespace WorldWide.Chimneys;

public class SleighHasTakenOffEventHandler(ILogger<SleighHasTakenOffEventHandler> logger, IRepository<Sleigh> sleighRepository, IRepository<Chimney> chimneyRepository) : IHandleMessages<SleighHasTakenOffEvent>
{
    private readonly ILogger<SleighHasTakenOffEventHandler> _logger = logger;
    private IRepository<Sleigh> _sleighRepository = sleighRepository;
    private IRepository<Chimney> _chimneyRepository = chimneyRepository;

  public async Task Handle(SleighHasTakenOffEvent message, IMessageHandlerContext context)
  {
    var sleigh = await _sleighRepository.SingleOrDefaultAsync(new SantasSleighSpecification(), context.CancellationToken);

    foreach (var present in sleigh!.Presents)
    {
      _logger.LogInformation($"Delivering present {present.Type} to {present.ChildName}");
      var chimney = await _chimneyRepository.SingleOrDefaultAsync(new ChimneyByChildNameSpec(present.ChildName), context.CancellationToken);
      sleigh.DeliverPresent(present, chimney!);
    }
  }
}
