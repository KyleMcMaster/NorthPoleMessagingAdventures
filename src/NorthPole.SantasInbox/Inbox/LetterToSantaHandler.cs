using NorthPole.Core.Letters;
using NorthPole.Core.NaughtyOrNice;

namespace NorthPole.SantasInbox.Inbox;

public class LetterToSantaHandler : IHandleMessages<LetterToSanta>
{
  private readonly NaughtyOrNiceList _naughtyOrNiceList;

  public LetterToSantaHandler(NaughtyOrNiceList naughtyOrNiceList)
  {
    _naughtyOrNiceList = naughtyOrNiceList;
  }

  public async Task Handle(LetterToSanta message, IMessageHandlerContext context)
  {
    bool isNice = _naughtyOrNiceList.IsNice(message.ChildName);

    var gift = isNice ? message.Gift : "Coal";

    await context.Send(new CreateGiftCommand(message.ChildName, gift));
  }
}

public class CreateGiftCommand : IMessage
{
  public string ChildName { get; init; }
  public string Gift { get; init; }

  public CreateGiftCommand(string childName, string gift)
  {
    ChildName = childName;
    Gift = gift;
  }
}
