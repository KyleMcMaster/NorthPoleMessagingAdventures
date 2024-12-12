namespace NorthPole.Core.Gifts;

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
