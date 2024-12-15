using NorthPole.Core.Gifts;
using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class AddGiftToSleighCommandHandler : IHandleMessages<AddGiftToSleighCommand>
{
    private readonly ILogger<AddGiftToSleighCommandHandler> _logger;

    public AddGiftToSleighCommandHandler(ILogger<AddGiftToSleighCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(AddGiftToSleighCommand message, IMessageHandlerContext context)
    {
        _logger.LogInformation("Sleigh received gift request from {ChildName} for {Gift}", message.ChildName, message.Gift);
        Guid sleighId = Guid.NewGuid(); // TODO: Get SleighId from this year's sleigh (repo)
        Guid chimneyId = Guid.NewGuid(); // TODO: Get ChimneyId from Child's address (repo)
        // TODO: add gift to sleigh
        _logger.LogInformation("Sleigh {SleighId} loaded with {Gift} for {ChildName} destined for {ChimneyId}", sleighId, message.Gift, message.ChildName, chimneyId);
        await context.Publish(new SleighLoadedWithNewGiftEvent(sleighId, chimneyId));
    }
}
