using NorthPole.Core.Gifts;
using NorthPole.Core.Letters;
using NorthPole.Core.NaughtyOrNice;

namespace NorthPole.SantasInbox.Inbox;

public class LetterToSantaHandler : IHandleMessages<LetterToSanta>
{
  private readonly ILogger _logger;
  private readonly NaughtyOrNiceList _naughtyOrNiceList;

  public LetterToSantaHandler(ILogger<LetterToSantaHandler> logger, NaughtyOrNiceList naughtyOrNiceList)
  {
    _logger = logger;
    _naughtyOrNiceList = naughtyOrNiceList;
  }

  public async Task Handle(LetterToSanta message, IMessageHandlerContext context)
  {
    _logger.LogInformation("Santa reading letter from {ChildName}", message.ChildName);
    bool isNice = _naughtyOrNiceList.IsNice(message.ChildName);
    _logger.LogInformation("Santa determined {ChildName} is {Status}.", message.ChildName, isNice ? "nice" : "naughty");
    var present = isNice ? message.Present : "Coal";

    _logger.LogInformation("Santa is giving {ChildName} the gift of {Present}", message.ChildName, present);
    await context.Send(new CreatePresentCommand(message.ChildName, present));
  }
}
