using Ardalis.SharedKernel;
using NorthPole.Core.Chimneys;
using NorthPole.Core.Presents;
using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class AddPresentToSleighCommandHandler : IHandleMessages<AddPresentToSleighCommand>
{
    private readonly ILogger<AddPresentToSleighCommand> _logger;
    private readonly IRepository<Chimney> _chimneyRepository;
    private readonly IRepository<Sleigh> _sleighRepository;
    private readonly IRepository<Present> _presentRepository;

    public AddPresentToSleighCommandHandler(
        ILogger<AddPresentToSleighCommand> logger,
        IRepository<Chimney> chimneyRepository,
        IRepository<Sleigh> sleighRepository,
        IRepository<Present> presentRepository)
    {
        _logger = logger;
        _chimneyRepository = chimneyRepository;
        _sleighRepository = sleighRepository;
        _presentRepository = presentRepository;
    }

    public async Task Handle(AddPresentToSleighCommand message, IMessageHandlerContext context)
    {
        var present = await _presentRepository.GetByIdAsync(message.PresentId, context.CancellationToken);
        var sleigh = await _sleighRepository.SingleOrDefaultAsync(new SantasSleighSpecification(), context.CancellationToken);
        var chimney = await _chimneyRepository.SingleOrDefaultAsync(new ChimneyByChildNameSpec(present!.ChildName), context.CancellationToken);
        present!.SetDestination(chimney!.Id);
        sleigh!.AddPresent(present);
        _logger.LogInformation("Sleigh {SleighId} loaded with {Present} for {ChildName} destined for {ChimneyId}", sleigh.Id, present.Type, present.ChildName, chimney.Id);
        await context.Publish(new SleighContainsNewPresentEvent(sleigh!.Id));
    }
}
