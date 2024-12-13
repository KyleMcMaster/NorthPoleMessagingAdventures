using NorthPole.Core.Gifts;

namespace NorthPole.SantasSleigh.Sleigh;

public class AddGiftToSleighCommandHandler : IHandleMessages<AddGiftToSleighCommand>
{
    private readonly ILogger<AddGiftToSleighCommandHandler> _logger;

    public AddGiftToSleighCommandHandler(ILogger<AddGiftToSleighCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AddGiftToSleighCommand message, IMessageHandlerContext context)
    {
        _logger.LogInformation("Sleigh received gift request from {ChildName} for {Gift}", message.ChildName, message.Gift);
        return Task.CompletedTask;
    }
}
