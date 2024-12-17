using Ardalis.SharedKernel;
using NorthPole.Core.Presents;
using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class AddPresentToSleighCommandHandler : IHandleMessages<AddPresentToSleighCommand>
{
    private readonly ILogger<AddPresentToSleighCommand> _logger;
    private readonly IRepository<Sleigh> _sleighRepository;
    private readonly IRepository<Present> _presentRepository;

    public AddPresentToSleighCommandHandler(ILogger<AddPresentToSleighCommand> logger,
    IRepository<Sleigh> sleighRepository,
    IRepository<Present> presentRepository)
    {
        _logger = logger;
        _sleighRepository = sleighRepository;
        _presentRepository = presentRepository;
    }

    public async Task Handle(AddPresentToSleighCommand message, IMessageHandlerContext context)
    {
        var present = await _presentRepository.GetByIdAsync(message.PresentId, context.CancellationToken);
        Guid sleighId = Guid.NewGuid(); // TODO: Get SleighId from this year's sleigh (repo)
        Guid chimneyId = Guid.NewGuid(); // TODO: Get ChimneyId from Child's address (repo)
        present!.SetDestination(chimneyId);
        // TODO: add gift to sleigh
        // _logger.LogInformation("Sleigh {SleighId} loaded with {Gift} for {ChildName} destined for {ChimneyId}", sleighId, message.Gift, message.ChildName, chimneyId);
        await context.Publish(new SleighContainsNewPresentEvent(sleighId));
    }
}
