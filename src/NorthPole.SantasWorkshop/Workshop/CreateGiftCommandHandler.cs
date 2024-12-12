using NorthPole.Core.Gifts;

namespace NorthPole.SantasWorkshop.Workshop;

public class CreateGiftCommandHandler : IHandleMessages<CreateGiftCommand>
{
    private readonly ILogger _logger;

    public CreateGiftCommandHandler(ILogger<CreateGiftCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CreateGiftCommand message, IMessageHandlerContext context)
    {
        _logger.LogInformation("Workshop received gift request from {ChildName} for {Gift}", message.ChildName, message.Gift);
        return Task.CompletedTask;
    }
}
